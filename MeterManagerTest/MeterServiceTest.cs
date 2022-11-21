using MeterManager.API.Controllers;
using MeterManager.API.Interfaces;
using MeterManager.API.Models;
using MeterManager.API.Models.Enums;
using MeterManager.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MeterApplicationTests
{
    public class MeterServiceTest
    {

        private readonly MeterService _meterMockService;
        private readonly Mock<IMeterRepository> _mockedMeterRepository = new Mock<IMeterRepository>();

        public List<MeterModel> MockedMeterList { get; set; }

        public MeterServiceTest()
        {

            _meterMockService = new MeterService(_mockedMeterRepository.Object);

            var registeredMeter_1 = new MeterModel
            {
                SerialNumber = "ASPX314",
                ModelId = MeterModelEnum.NSX2P3W,
                SwitchState = SwitchStateEnum.Connected,
                Number = 1,
                FirmwareVersion = "1.33_V2"
            };
            var registeredMeter_2 = new MeterModel
            {
                SerialNumber = "ASPX317",
                ModelId = MeterModelEnum.NSX1P2W,
                SwitchState = SwitchStateEnum.Disconnected,
                Number = 2,
                FirmwareVersion = "1.123_V1"
            }; var registeredMeter_3 = new MeterModel
            {
                SerialNumber = "ASPX311",
                ModelId = MeterModelEnum.NSX2P3W,
                SwitchState = SwitchStateEnum.Connected,
                Number = 3,
                FirmwareVersion = "1.03_V3"
            };
            MockedMeterList = new List<MeterModel> { registeredMeter_1, registeredMeter_2, registeredMeter_3 };
        }

        [Fact]
        public void GetBySerialNumberGet_ReturnsMeterModelResult()
        {
            _mockedMeterRepository.Setup(m => m.GetBySerialNumberAsync(It.IsAny<string>())).ReturnsAsync(MockedMeterList[0]);

            var result = _meterMockService.GetBySerialNumberAsync(MockedMeterList[0].SerialNumber).Result;
            Assert.Equal(MockedMeterList[0], result);
        }

        [Fact]
        public async void GetAllAsync_ReturnsMeterModelListResult()
        {
            _mockedMeterRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(MockedMeterList);

            var result = await _meterMockService.GetAllAsync();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void CreateAsyncTest_ReturnsCreatedResult()
        {

            var newMeter = new MeterModel
            {
                SerialNumber = "ASPX400",
                ModelId = MeterModelEnum.NSX2P3W,
                SwitchState = SwitchStateEnum.Armed,
                Number = 7,
                FirmwareVersion = "1.0_V5"
            };

            _mockedMeterRepository.Setup(m => m.CreateAsync(newMeter)).ReturnsAsync(newMeter);

            var result = _meterMockService.CreateAsync(newMeter).Result;
            Assert.Equal(newMeter, result);
        }

        //The test is failing because at the time of finding the existing object to update it is not found.
        [Fact]
        public async void UpdateAsyncTest_ReturnsCreatedResult()
        {
            var meterToUpdate = new MeterModel
            {
                SerialNumber = "ASPX314",
                ModelId = MeterModelEnum.NSX2P3W,
                SwitchState = SwitchStateEnum.Disconnected,
                Number = 7,
                FirmwareVersion = "1.0_V5"
            };
            
            _mockedMeterRepository.Setup(m => m.UpdateAsync(meterToUpdate)).ReturnsAsync(meterToUpdate);
            
            var result = await _meterMockService.UpdateAsync(meterToUpdate);
            Assert.Equal(meterToUpdate, result);
        }
    }
}