using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingLot;
using ParkingLot.Comman;
using ParkingLot.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotTests.Storage
{
    [TestClass]
    public class _parkingDataTest
    {
        private IParkingData _parkingData;
        private Mock<IOutput> _mockOutput;

        [TestInitialize]
        public void Setup()
        {
            _mockOutput = new Mock<IOutput>();

            _parkingData = ParkingData.Instance(_mockOutput.Object);

            _parkingData.CreateParkingLot(2);
        }

        [TestCleanup]
        public void TearDown()
        {
            for(int i = 0; i< _parkingData.SlotsLength; i++)
            {
                _parkingData.VacateSlot(i + 1);
            }
        }


        [TestMethod]
        public void CreateParkingLot_SlotsAlreadyCreated_ReturnsFalse()
        {
            var res2 = _parkingData.CreateParkingLot(2);

            Assert.IsFalse(res2);

        }

        [TestMethod]
        public void VacateSlot_ReturnsTrue()
        {
            var park = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-12-GG-1234", 21));
            var res2 = _parkingData.VacateSlot(1);

            Assert.IsTrue(park);
            Assert.IsTrue(res2);

        }

        [TestMethod]
        public void VacateSlot_SlotsAlreadyVacated_ReturnsFalse()
        {
            var res2 = _parkingData.VacateSlot(1);

            Assert.IsFalse(res2);

        }

        [TestMethod]
        public void VacateSlot_InValidSlotNumber_ReturnsFalse()
        {
            var res2 = _parkingData.VacateSlot(3);

            Assert.IsFalse(res2);
        }

        [TestMethod]
        public void AddTicket_ReturnsTrue()
        {
            var park = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-12-GG-1234", 21));

            Assert.IsTrue(park);
        }

        [TestMethod]
        public void AddTicket_VehicleAlreadtParked_ReturnsFalse()
        {
            var park1 = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-12-GG-1234", 21));
            var park2 = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-12-GG-1234", 21));

            Assert.IsTrue(park1);
            Assert.IsFalse(park2);
        }

        [TestMethod]
        public void AddTicket_SlotsFull_ReturnsFalse()
        {
            var park1 = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-12-GG-1234", 21));
            var park2 = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-13-GG-1234", 21));
            var park3 = _parkingData.AddTicket(new ParkingLot.Comman.Model.ParkingTicket("KA-14-GG-1234", 21));

            Assert.IsTrue(park1);
            Assert.IsTrue(park2);
            Assert.IsFalse(park3);

        }
    }
}
