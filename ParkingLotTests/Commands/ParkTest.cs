using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot;
using ParkingLot.Comman;
using ParkingLot.Comman.Model;
using ParkingLot.Commands;
using ParkingLot.Repository;
using ParkingLot.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotTests.Commands
{
    [TestClass]
    public class ParkTest
    {
            [TestMethod]
            public void GivenValidRegistrationNumber_Executes_Successfully()
            {
                var mockOutput = new Mock<IOutput>();
                var mockDb = new Mock<ITicketRepo>();

                var park = new Park(mockDb.Object, mockOutput.Object);

                park.Execute(new string[] { "park", "KA-12-HH-1234","driver_age", "23"});

                mockDb.Verify(x => x.AddTicket("ka-12-hh-1234", 23), Times.Once);
            }

            [TestMethod]
            public void GivenInValidRegistrationNumber_Executes_PrintsError()
            {
                var mockOutput = new Mock<IOutput>();
                var mockDb = new Mock<ITicketRepo>();

                var park = new Park(mockDb.Object, mockOutput.Object);

                park.Execute(new string[] { "park", "KA-12-HH-123f4", "driver_age", "23" });

                mockOutput.Verify(x => x.PrintLine(Messages.InvalidVehicleNumber), Times.Once);
            }

            [TestMethod]
            public void GivenInValidCommand_Executes_PrintsError()
            {
                var mockOutput = new Mock<IOutput>();
                var mockDb = new Mock<ITicketRepo>();

                var park = new Park(mockDb.Object, mockOutput.Object);

                park.Execute(new string[] { "park", "KA-12-HH-1234", "drivser_age", "23" });

                mockOutput.Verify(x => x.PrintLine(Messages.ParkInvalidArgument), Times.Once);
            }

            [TestMethod]
            public void GivenInValidDriverAge_Executes_PrintsError()
            {
                var mockOutput = new Mock<IOutput>();
                var mockDb = new Mock<ITicketRepo>();

                var park = new Park(mockDb.Object, mockOutput.Object);

                park.Execute(new string[] { "park", "KA-12-HH-1234", "driver_age", "aa" });

                mockOutput.Verify(x => x.PrintLine(Messages.InvalidAge), Times.Once);
            }

            [TestMethod]
            public void GivenInValidParkCommand_Executes_PrintsError()
            {
                var mockOutput = new Mock<IOutput>();
                var mockDb = new Mock<ITicketRepo>();

                var park = new Park(mockDb.Object, mockOutput.Object);

                park.Execute(new string[] { "parkasff", "KA-12-HH-1234", "driver_age", "23" });

                mockOutput.Verify(x => x.PrintLine(Messages.ShowCommand), Times.Once);
            }
    }
}
