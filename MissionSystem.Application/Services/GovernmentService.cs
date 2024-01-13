using MissionSystem.Application.Contracts;
using MissionSystem.Application.DTOs.Authentication;
using MissionSystem.Domain.Entity;
using MissionSystem.Infrastructure.Repositories.GovernmentRepository;

namespace MissionSystem.Application.Services
{
    public class GovernmentService
    {
        #region CTOR
        private readonly IGovernmentRepository _repository;
        private readonly IGenericRepository<Government> _generic;

        public GovernmentService(IGovernmentRepository repository, IGenericRepository<Government> generic)
        {
            _repository = repository;
            _generic = generic;
        }
        #endregion
        public async Task<string> AddGovernmentAsync(Government government)
        {
            return await _repository.CreateAsync(government);
        }

        public async Task<string> DeleteGovernmentAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Government>> GetAllGovernmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Government> GetGovernmentByIdAsync(Guid id)
        {
            return await _repository.GetById(a => a.Id == id);
        }
        public async Task<ResponseDto> SeedGovernmentAsync()
        {
            var isAlexandria = await _repository.GetByNameAsync("Alexandria");
            var isMatrouh    = await _repository.GetByNameAsync("Matrouh");
            var isBeheira    = await _repository.GetByNameAsync("Beheira");
            var isKafr       = await _repository.GetByNameAsync("Kafr El Sheikh");
            var isDakahlia   = await _repository.GetByNameAsync("Dakahlia");
            var isDamietta   = await _repository.GetByNameAsync("Damietta");
            var isAPort      = await _repository.GetByNameAsync("Port Said");
            var isNorth      = await _repository.GetByNameAsync("North Sinai");
            var isGharbia    = await _repository.GetByNameAsync("Gharbia");
            var isMonufia    = await _repository.GetByNameAsync("Monufia");
            var isAQalyubia  = await _repository.GetByNameAsync("Qalyubia");
            var isSharqia    = await _repository.GetByNameAsync("Sharqia");
            var isIsmailia   = await _repository.GetByNameAsync("Ismailia");
            var isGiza       = await _repository.GetByNameAsync("Giza");
            var isFaiyum     = await _repository.GetByNameAsync("Faiyum");
            var isCairo      = await _repository.GetByNameAsync("Cairo");
            var isSuez       = await _repository.GetByNameAsync("Suez");
            var isSouth      = await _repository.GetByNameAsync("South Sinai");
            var isBeni       = await _repository.GetByNameAsync("Beni Suef");
            var isMinya      = await _repository.GetByNameAsync("Minya");
            var isNew        = await _repository.GetByNameAsync("New Valley");
            var isAsyut      = await _repository.GetByNameAsync("Asyut");
            var isRed        = await _repository.GetByNameAsync("Red Sea");
            var isSohag      = await _repository.GetByNameAsync("Sohag");
            var isQena       = await _repository.GetByNameAsync("Qena");
            var isLuxor      = await _repository.GetByNameAsync("Luxor");
            var isAswan      = await _repository.GetByNameAsync("Aswan");

            if (isAlexandria && isMatrouh && isBeheira && isKafr && isDakahlia && isDamietta && isAPort && isNorth && isGharbia && isMonufia && isAQalyubia && isSharqia && isIsmailia && isGiza && isFaiyum && isCairo && isSuez && isSouth && isBeni && isMinya && isNew && isAsyut && isRed && isSohag && isQena && isLuxor && isAswan)
                return new ResponseDto()
                {                                                   
                    IsSuccess = true,                               
                    DisplayMessage = "Governments Seeding is Already Done"
                };

            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Matrouh", GovernmentNameAr = "مطروح" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Alexandria", GovernmentNameAr = "الاسكندرية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Beheira", GovernmentNameAr = "البحيرة" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Kafr El Sheikh", GovernmentNameAr = "كفر الشيخ"});
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Dakahlia", GovernmentNameAr = "الدقهلية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Damietta", GovernmentNameAr = "دمياط" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Port Said", GovernmentNameAr = "بورسعيد" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "North Sinai", GovernmentNameAr = "شمال سينا" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Gharbia", GovernmentNameAr = "الغربية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Monufia", GovernmentNameAr = "المنوفية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Qalyubia", GovernmentNameAr = "القليوبية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Sharqia", GovernmentNameAr = "الشرقية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Ismailia", GovernmentNameAr = "الاسماعيلية" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Giza", GovernmentNameAr = "الجيزة" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Faiyum", GovernmentNameAr = "الفيوم" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Cairo", GovernmentNameAr = "القاهرة" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Suez", GovernmentNameAr = "السويس" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "South Sinai", GovernmentNameAr = "جنوب سينا" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Beni Suef", GovernmentNameAr = "بني سويف" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Minya", GovernmentNameAr = "المنيا" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "New Valley", GovernmentNameAr = "الوادي الجديد" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Asyut", GovernmentNameAr = "اسيوط" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Red Sea", GovernmentNameAr = "البحر الاحمر" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Sohag", GovernmentNameAr = "سوهاج" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Qena", GovernmentNameAr = "قنا" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Luxor", GovernmentNameAr = "الاقصر" });
            await _generic.CreateAsync(new Government { Id = Guid.NewGuid(), GovernmentNameEn = "Aswan", GovernmentNameAr = "اسوان" });

            return new ResponseDto()                                  
            {                                                       
                IsSuccess = true,                                   
                DisplayMessage = "Governments Seeding Done Successfully"   
            };                                                      
        }
    }
}
