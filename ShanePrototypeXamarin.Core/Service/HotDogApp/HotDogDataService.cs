using System;
using System.Collections.Generic;
using ShanePrototypeXamarin.Core.Repository.HotDogApp;
using ShanePrototypeXamarin.Core.ViewModels;
using ShanePrototypeXamarin.Core.ViewModels.HoDogsApp;

namespace ShanePrototypeXamarin.Core.Service.HotDogApp
{
    public class HotDogDataService
    {
        private static HotDogRepository hotDogRepository = new HotDogRepository();

        public HotDogDataService()
        {
        }

		public List<HotDog> GetAllHotDogs()
		{
			return hotDogRepository.GetAllHotDogs();
		}

		public List<HotDogGroup> GetGroupedHotDogs()
		{
			return hotDogRepository.GetGroupedHotDogs();
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
		{
			return hotDogRepository.GetHotDogsForGroup(hotDogGroupId);
		}

		public List<HotDog> GetFavoriteHotDogs()
		{
			return hotDogRepository.GetFavoriteHotDogs();
		}

		public HotDog GetHotDogById(int hotDogId)
		{
			return hotDogRepository.GetHotDogById(hotDogId);
		}
    }
}
