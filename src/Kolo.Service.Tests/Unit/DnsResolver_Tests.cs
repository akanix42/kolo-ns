using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARSoft.Tools.Net.Dns;
using FluentAssertions;
using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.Models;
using Kolo.Core.Services;
using Kolo.Service.Services;
using Moq;
using NPoco;
using NUnit.Framework;

namespace Kolo.Service.Tests.Unit
{
    [TestFixture]
    class DnsResolver_Tests
    {

        [Test]
        public void Should_Return_DNS_Error_Because_No_Entry_Was_Requested()
        {
            var dnsResolver = Mock.Of<IDnsResolver>();
            IDnsQueryHandler queryHandler = new DnsQueryHandler(dnsResolver);
            var message = new DnsMessage();
            DnsMessageBase processedMessage = queryHandler.HandleQuery(message, null, KeyRecordBase.ProtocolType.Any);
            processedMessage.ReturnCode.Should().Be(ReturnCode.ServerFailure);
        }

        [Test]
        public void Should_Return_Non_Existent_Domain_Because_No_Entry_Matches()
        {
            var dnsResolver = Mock.Of<IDnsResolver>(mock => mock.Resolve(It.IsAny<DnsRequest>()) == new DnsResolutionResult());
            IDnsQueryHandler queryHandler = new DnsQueryHandler(dnsResolver);
            var message = new DnsMessage() {Questions = new List<DnsQuestion>() {new DnsQuestion("test", RecordType.A, RecordClass.Any)}};
            DnsMessageBase processedMessage = queryHandler.HandleQuery(message, null, KeyRecordBase.ProtocolType.Any);
            processedMessage.ReturnCode.Should().Be(ReturnCode.NxDomain);
        }

        [Test]
        public void Should_Return_No_Error_Because_Entry_Matches()
        {
            var dnsResolver = Mock.Of<IDnsResolver>(mock => mock.Resolve(It.IsAny<DnsRequest>()) == new DnsResolutionResult()
            {
                DnsEntry = new DnsEntry() { Name = "test", IpV4 = "0.0.0.0"}
            });
            IDnsQueryHandler queryHandler = new DnsQueryHandler(dnsResolver);
            var message = new DnsMessage() { Questions = new List<DnsQuestion>() { new DnsQuestion("test", RecordType.A, RecordClass.Any) } };
            queryHandler.HandleQuery(message, null, KeyRecordBase.ProtocolType.Any);
            message.ReturnCode.Should().Be(ReturnCode.NoError);
        }

        [Test]
        public void Should_Return_Answer_Because_Entry_Matches()
        {
            var dnsResolver = Mock.Of<IDnsResolver>(mock => mock.Resolve(It.IsAny<DnsRequest>()) == new DnsResolutionResult()
            {
                DnsEntry = new DnsEntry() { Name = "test", IpV4 = "0.0.0.0"}
            });
            IDnsQueryHandler queryHandler = new DnsQueryHandler(dnsResolver);
            var message = new DnsMessage() { Questions = new List<DnsQuestion>() { new DnsQuestion("test", RecordType.A, RecordClass.Any) } };
            queryHandler.HandleQuery(message, null, KeyRecordBase.ProtocolType.Any);
            message.AnswerRecords.Single().Name.Should().Be("test");
        }
    }
}
