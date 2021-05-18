﻿using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace TrashHandling.Models
{
	public class Validation
    {
        /// <summary>
        /// Checks the company id against an API and returns if it is real.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="id">The company id</param>
        /// <returns>true if company is found in the API</returns>
        public static bool ValidCompanyInfo(int id)
        {
            try
            {
                JObject json;
                using (var webClient = new WebClient())
                {
                    webClient.Headers["User-Agent"] = "Uddannelses Projekt";
                    string content = webClient.DownloadString(string.Format("http://cvrapi.dk/api?search={0}&country=dk", id));
                    json = JObject.Parse(content);
                }
                return !json.ContainsKey("error");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
