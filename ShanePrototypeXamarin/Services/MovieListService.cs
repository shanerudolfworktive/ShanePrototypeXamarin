﻿using System;
using System.Net.Http;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
namespace ShanePrototypeXamarin.Services
{
    public class MovieListService
    {
        public static readonly int MinSearchLength = 5;

        private const string BaseUrl = "http://netflixroulette.net/api/api.php";

        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Modals.MovieModal>> FindMoviesByActorName(String actorName){
			if (actorName.Length < MinSearchLength)
                return Enumerable.Empty<Modals.MovieModal>();

            var response = await _client.GetAsync($"{BaseUrl}?actor={actorName}");

			if (response.StatusCode == HttpStatusCode.NotFound)
				return Enumerable.Empty<Modals.MovieModal>();

			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Modals.MovieModal>>(content);
        }
    }
}
