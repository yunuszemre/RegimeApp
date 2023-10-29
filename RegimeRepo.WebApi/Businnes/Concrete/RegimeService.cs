using Microsoft.EntityFrameworkCore;
using RegimeRepo.WebApi.ApplicationDbContext;
using RegimeRepo.WebApi.Businnes.Abstract;
using RegimeRepo.WebApi.Entites.Concrete;
using RegimeRepo.WebApi.Models;
using RegimeRepo.WebApi.Models.DTO;

namespace RegimeRepo.WebApi.Businnes.Concrete
{
    public class RegimeService : IRegimeService
    {
        private readonly hakanhak_HakanHakyemezContext _contex;
        public RegimeService(hakanhak_HakanHakyemezContext contex)
        {
            _contex = contex;
        }
        public async Task<ReturnModel<RegimeReturnModel>> Add(AddOrUpdateRegimeDto dto)
        {
            var returnModel = new ReturnModel<RegimeReturnModel>();
            var entity = new RegimeEntity()
            {
                EveningSport = dto.EveningSport,
                LaunchSport = dto.LaunchSport,
                WeightDifference = dto.WeightDifference,
                Coffee = dto.Coffee,
                BreakFastTime = dto.BreakFastTime,
                DinnerTime = dto.DinnerTime,
                DrinkWater = dto.DrinkWater,
                Fruits = dto.Fruits,
                PlannedDate = dto.PlannedDate,
                UpdatedDate = dto.UpdatedDate,
                UpdatedUserId = dto.UpdatedUserId,
                CreatedDate = DateTime.Now,
                CreatedUserId = dto.CreatedUserId,
                StepCount = dto.StepCount,
                UserId = dto.UserId,
                Fails = dto.Fails,
            };
            await _contex.Regimes.AddAsync(entity);
            var result = _contex.SaveChanges();
            if (result <= 0)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.AddErrorMessage;
                return returnModel;
            }            
            returnModel.IsSuccess = true;
            returnModel.Message = Constants.SuccesfulAddMessage;
            return returnModel;

        }
        public async Task<ReturnModel<RegimeReturnModel>> Delete(Guid Id)
        {
            var returnModel = new ReturnModel<RegimeReturnModel>();
            var regime = await _contex.Regimes.FirstOrDefaultAsync(x => x.Id == Id);
            if (regime == null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.EntityNotFound;
                return returnModel;
            }
            _contex.Regimes.Remove(regime);
            _contex.SaveChanges();

            returnModel.IsSuccess = true;
            returnModel.Message = Constants.SuccesfulDelete;

            return returnModel;
        }

        public async Task<ReturnModel<List<RegimeEntity>>> GetAll()
        {
            var returnModel = new ReturnModel<List<RegimeEntity>>();
            var regimes = await _contex.Regimes.ToListAsync();
            if (regimes == null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.EntityNotFound;
                return returnModel;
            }
            if (regimes.Count() == 0)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.EntityNotFound;
                return returnModel;
            }
            returnModel.IsSuccess = true;
            returnModel.Message = Constants.Succes;
            returnModel.Data = regimes;

            return returnModel;
        }

        public async Task<ReturnModel<RegimeEntity>> GetById(Guid id)
        {
            var returnModel = new ReturnModel<RegimeEntity>();
            var result = (from regimes in _contex.Regimes
                                         join user in _contex.Users on regimes.UserId equals user.Id
                                         where regimes.Id == id
                                         select regimes).FirstOrDefault();           
            if (result == null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.EntityNotFound;
                return returnModel;
            }

            returnModel.IsSuccess = true;
            returnModel.Message = Constants.Succes;
            returnModel.Data = result;

            return returnModel;
        }

        public async Task<ReturnModel<List<RegimeEntity>>> GetByUserIdAll(Guid Id)
        {
            var returnModel = new ReturnModel<List<RegimeEntity>>();
            var r = await _contex.Regimes.Where(x => x.UserId == Id).ToListAsync();
            if (r.Count <= 0)
            {
                returnModel.IsSuccess = true;
                returnModel.Message = Constants.EntityNotFound;
            }
            returnModel.IsSuccess = true;
            returnModel.Message = Constants.Succes;
            returnModel.Data = r;

            return returnModel;
        }

        public async Task<ReturnModel<RegimeReturnModel>> Update(AddOrUpdateRegimeDto dto)
        {
            var returnModel = new ReturnModel<RegimeReturnModel>();
            var entity = await _contex.Regimes.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.EntityNotFound;
                return returnModel;
            }

            entity.EveningSport = dto.EveningSport;
            entity.LaunchSport = dto.LaunchSport;
            entity.WeightDifference = dto.WeightDifference;
            entity.Coffee = dto.Coffee;
            entity.BreakFastTime = dto.BreakFastTime;
            entity.DinnerTime = dto.DinnerTime;
            entity.DrinkWater = dto.DrinkWater;
            entity.Fruits = dto.Fruits;
            entity.PlannedDate = dto.PlannedDate;
            entity.UpdatedDate = dto.UpdatedDate;
            entity.UpdatedUserId = dto.UpdatedUserId;
            entity.StepCount = dto.StepCount;
            entity.Fails = dto.Fails;

            _contex.Regimes.Update(entity);

            var result = _contex.SaveChanges();
            if (result <= 0)
            {
                returnModel.IsSuccess = false;
                returnModel.Message = Constants.UpdateFailMessage;
                return returnModel;
            }

            returnModel.IsSuccess = true;
            returnModel.Message = Constants.Succes;
            return returnModel;
        }
    }
}
