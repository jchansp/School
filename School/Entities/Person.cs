﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Entities
{
    public class Person
    {
        public object Name { get; set; }
        public object Country { get; set; }

        protected void RandomPopulate()
        {
            Name = RandomName();
            Country = RandomCountry();
        }

        private object RandomCountry()
        {
            var items = new List<Country>();
            var connectionString =
                ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetRandomCountryName", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();

                    //SqlParameter custId = cmd.Parameters.AddWithValue("@CustomerId", 10);

                    //using (var dr = command.ExecuteReader())
                    //{
                    //    if (dr.Read())
                    //    {
                    //        Label1.Text = dr["Name"].ToString();
                    //    }
                    //}

                    return command.ExecuteScalar();
                    conn.Close();
                }
            }

            //return Repositories.Countries.Get();
            return new List<string>
            {
                "Algeria",
                "Angola",
                "Botswana",
                "Burkina Faso",
                "Burundi",
                "Cameroon",
                "Central African Republic",
                "Chad",
                "Congo DR",
                "Congo RO",
                "Egypt",
                "Eritrea",
                "Ethiopia",
                "Gambia",
                "Ghana",
                "Guinea",
                "Guinea-Bissau",
                "Ivory Coast",
                "Kenya",
                "Lesotho",
                "Liberia",
                "Libya",
                "Madagascar",
                "Malawi",
                "Mauritania",
                "Morocco",
                "Mozambique",
                "Namibia",
                "Niger",
                "Nigeria",
                "Rwanda",
                "Senegal",
                "Sierra Leone",
                "Somalia",
                "South Africa",
                "Sudan",
                "Suriname",
                "Swaziland",
                "Tanzania",
                "Togo",
                "Tunisia",
                "Western Sahara",
                "Yemen",
                "Zambia",
                "Zimbabwe",
                "Afghanistan",
                "Armenia",
                "Azerbaijan",
                "Bahrain",
                "Bangladesh",
                "Bhutan",
                "Cambodia",
                "China (Hong Kong)",
                "East Timor",
                "Georgia",
                "India",
                "Iran",
                "Iraq",
                "Japan",
                "Jordan",
                "Kazakhstan",
                "Kuwait",
                "Kyrgyzstan",
                "Malaysia",
                "Mongolia",
                "Myanmar",
                "Nepal",
                "North Korea",
                "Oman",
                "Pakistan",
                "Palestinian territories",
                "Papua New Guinea",
                "Qatar",
                "Saudi Arabia",
                "Singapore",
                "South Korea",
                "Sri Lanka",
                "Syria",
                "Taiwan",
                "Tajikistan",
                "Thailand",
                "Turkey",
                "Turkmenistan",
                "United Arab Emirates",
                "Uzbekistan",
                "Vietnam",
                "Albania",
                "Austria",
                "Belarus",
                "Belgium",
                "Bosnia and Herzegovina",
                "Bulgaria",
                "Croatia",
                "Cyprus",
                "Czech Republic",
                "Denmark",
                "Estonia",
                "Finland",
                "France",
                "Germany",
                "Greece",
                "Hungary",
                "Iceland",
                "Ireland",
                "Italy",
                "Latvia",
                "Lithuania",
                "Macedonia",
                "Moldova",
                "Montenegro",
                "Netherlands",
                "Poland",
                "Portugal",
                "Romania",
                "Russia",
                "Serbia",
                "Slovakia",
                "Slovenia",
                "Spain",
                "Sweden",
                "Switzerland",
                "Ukraine",
                "United Kingdom",
                "Bahamas",
                "Belize",
                "Canada",
                "Costa Rica",
                "Cuba",
                "Dominican Republic",
                "El Salvador",
                "Greenland",
                "Guatemala",
                "Haiti",
                "Honduras",
                "Jamaica",
                "Mexico",
                "Netherlands",
                "Nicaragua",
                "Panama",
                "Trinidad and Tobago",
                "United States (Puerto Rico)",
                "Australia",
                "Fiji",
                "New Zealand",
                "Argentina",
                "Bolivia",
                "Brazil",
                "Chile",
                "Colombia",
                "Ecuador",
                "Guyana",
                "Paraguay",
                "Peru",
                "Uruguay",
                "Venezuela"
            }.OrderBy(s => Guid.NewGuid()).First();
        }

        private object RandomName()
        {
            return
                new List<string>
                {
                    "Hugo",
                    "Daniel",
                    "Pablo",
                    "Alejandro",
                    "Álvaro",
                    "Adrián",
                    "David",
                    "Mario",
                    "Diego",
                    "Javier"
                }.OrderBy(s => Guid.NewGuid()).First();
        }
    }
}