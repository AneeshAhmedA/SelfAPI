using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Self.DTO;
using Self.Entity;
using Self.Service;

namespace Self.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public TrainController(ITrainService trainService, IMapper mapper, ILog logger = null)
        {
            _trainService = trainService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        //[Authorize(Roles = "User")]
        public IActionResult CreateTrain([FromBody] trainDTO trainDTO)
        {
            try
            {
                var train = _mapper.Map<Train>(trainDTO);
                _trainService.CreateTrain(train);
                _logger?.Info($"Train created successfully. Train No: {train.trainNo}");
                return StatusCode(200, train.trainNo);
            }
            catch (Exception ex)
            {
                _logger?.Error($"Error creating train: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{trainNo}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetWalletByTrainNo(int trainNo)
        {
            try
            {
                var wallet = _trainService.GetTrainByTrainNo(trainNo);

                if (wallet == null)
                {
                    _logger?.Warn($"Wallet with ID {trainNo} not found.");
                    return NotFound();
                }

                var trainDTO = _mapper.Map<trainDTO>(wallet);
                _logger?.Info($"Retrieved wallet by ID successfully. Wallet ID: {trainNo}");
                return StatusCode(200, trainDTO);
            }
            catch (Exception ex)
            {
                _logger?.Error($"Error getting wallet by ID: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllTrains()
        {
            try
            {
                var wallets = _trainService.GetAllTrains();
                var walletDTOs = _mapper.Map<List<trainDTO>>(wallets);
                _logger?.Info("Retrieved all wallets successfully.");
                return StatusCode(200, walletDTOs);
            }
            catch (Exception ex)
            {
                _logger?.Error($"Error getting all wallets: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPut("{walletId}")]
        //[Authorize(Roles = "Admin, User")]
        //public IActionResult UpdateWallet(int walletId, [FromBody] WalletDTO updatedWalletDTO)
        //{
        //    try
        //    {
        //        var updatedWallet = _mapper.Map<Train>(updatedWalletDTO);
        //        _trainService.UpdateTrain(walletId, updatedWallet);
        //        _logger?.Info($"Wallet updated successfully. Wallet ID: {walletId}");
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger?.Error($"Error updating wallet: {ex.Message}");
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpDelete("{walletId}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult DeleteWallet(int trainNo)
        {
            try
            {
                _trainService.DeleteTrain(trainNo);
                _logger?.Info($"Wallet deleted successfully. Wallet ID: {trainNo}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger?.Error($"Error deleting wallet: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
