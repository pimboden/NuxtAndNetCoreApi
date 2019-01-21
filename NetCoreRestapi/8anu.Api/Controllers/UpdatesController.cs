using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _8anu.Api.Common;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]/{slug?}")]
    public class UpdatesController : Controller
    {
        public UpdatesController()
        {
        }

        /*
        [HttpPost]
        public ContentResult GetUpdates(QueryUpdates params) // models
        {
            var json = @"{RankingRoutes: {}}";

            return new ContentResult { Content = json, ContentType = "application/json" };
        }
        */

        // get updates should return something like:
/*
        {

Api.Controllers
    - UpdatesController

Managers

    UpdatesManager
        - rankingsREPO
        - ascentsREPO


        RankingsManager

        LatestAscentsManager
            - user whatever repositories in the mangers





    rankings:
    [
        {
            "country": "",
            "category": "sportsclimbing",
            "gender": "male",
            "age": "all",
            "limit": 3,
            "items":

            [
                { "rank": 1, "score": 12050, user: { "slug": "user-slug", "firstName": "Cedrik", "lastName": "Berger" }
}
                { "rank": 2, "score": 12000, user: { "slug": "user-slug", "firstName": "Niilo", "lastName": "Ferlitsch" } }
                { "rank": 1, "score": 11811, user: { "slug": "user-slug", "firstName": "Jane", "lastName": "Kronberger" } }
            ]
        }, 
        {
            "country": "",
            "category": "bouldering",
            "gender": "all",
            "age": "all"
            "limit": 3,
            "items":
            [
                { "rank": 1, "score": 11600, user: { "slug": "user-slug", "firstName": "Cedrik", "lastName": "Rauch" } }
                { "rank": 2, "score": 10970, user: { "slug": "user-slug", "firstName": "Alex", "lastName": "Dornauer" } }
                { "rank": 1, "score": 10600, user: { "slug": "user-slug", "firstName": "Bob", "lastName": "Schwalger" } }
            ]
        }
    ],
    LatestAscents: 
    [
        { 
            "gender": "male",
            "top": 5,
            ascent: 

            [
                { ascent -> with users }
            ] 
        } 
    ]
}



*/


    }
}