using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot;
using ParkingLot.Comman;
using ParkingLot.Commands;
using ParkingLot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotTests.Commands
{
    [TestClass]
    public class LeaveSlotTest
    {
        [TestMethod]
        public void GivenValidRegistrationNumber_Executes_Successfully()
        {
            var mockOutput = new Mock<IOutput>();
            var mockDb = new Mock<ITicketRepo>();

            var leaveSlot = new LeaveSlot(mockDb.Object, mockOutput.Object);

            leaveSlot.Execute(new string[] { "leave", "2"});

            mockDb.Verify(x => x.LeaveSlot(2), Times.Once);
        }


        [TestMethod]
        public void GivenInValidCommand_Executes_PrintsError()
        {
            var mockOutput = new Mock<IOutput>();
            var mockDb = new Mock<ITicketRepo>();

            var leaveSlot = new LeaveSlot(mockDb.Object, mockOutput.Object);

            leaveSlot.Execute(new string[] { "leasve", "2" });

            mockOutput.Verify(x => x.PrintLine(Messages.ShowCommand), Times.Once);
        }

        [TestMethod]
        public void GivenInValidDriverAge_Executes_PrintsError()
        {
            var mockOutput = new Mock<IOutput>();
            var mockDb = new Mock<ITicketRepo>();

            var leaveSlot = new LeaveSlot(mockDb.Object, mockOutput.Object);

            leaveSlot.Execute(new string[] { "leave", "a" });

            mockOutput.Verify(x => x.PrintLine(Messages.InvalidSlotNumber), Times.Once);
        }

    }
}
