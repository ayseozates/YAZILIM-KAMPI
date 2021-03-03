using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;

        public CarManager(ICarDal carDal,IColorService colorService )
        {
            _carDal = carDal;
        
            _colorService = colorService;
        }

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("product.add,admin")]
      [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            // Aynı isimde araba eklenemez
            //Eğer mevcut kategori sayısı 15 i geçtiyse sisteme ürün eklenemez.
          IResult result=  BusinessRules.Run(CheckCarNameExists(car.CarName), CheckIfCarCountOfColorCorrect(car.ColorId),CheckIfColorCountLimitExceded());
            //business codes
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

          
         //   return new ErrorResult();
            
            
           
        } 

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        public IDataResult<Car> GetById(int carId)
        {
            // markasına göre tek bir araç döndürür.
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id ==carId));
        }
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==18)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return  new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == colorId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        private  IResult CheckIfCarCountOfColorCorrect(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfColorError);
            }
            return new SuccessResult();

        }
        private IResult CheckCarNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();//var mı
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);

            }
            return new SuccessResult();
        }
        private IResult CheckIfColorCountLimitExceded()
        {
            var result = _colorService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.ColorLimitExceded);

            }
            return new SuccessResult();
        }

        }
    }

