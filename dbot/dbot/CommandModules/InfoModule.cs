﻿using dbot.Services;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dbot.CommandModules
{
    [Group("info")]
    class InfoModule : ModuleBase
    {
        private readonly OmdbService _omdbService;
        public InfoModule(OmdbService omdbService)
        {
            _omdbService = omdbService;
        }

        [Command]
        public async Task Default(string movieName)
        {
            var movie = await _omdbService.GetMovieByTitle(movieName);
            await ReplyAsync(movie.ToString());
        }

        [Command]
        public async Task Default(string movieName, int year)
        {
            var movie = await _omdbService.GetMovieByTitleYear(movieName, year);
            await ReplyAsync(movie.ToString());
        }
    }
}
