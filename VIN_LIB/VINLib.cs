    using System;
using System.Collections.Generic;

namespace VIN_LIB
{
    public static class VINLib
    {
        public static bool CheckVIN(string vin)
        {
            if (vin.Length != 17) return false;
            var result = 0;
            var index = 0;
            var checkDigit = 0;
            var checkSum = 0;
            var weight = 0;
            foreach (var c in vin.ToCharArray())
            {
                index++;
                var character = c.ToString().ToLower();
                if (char.IsNumber(c)) result = int.Parse(character);
                else
                {
                    switch (character)
                    {
                        case "a":
                        case "j":
                            result = 1;
                            break;
                        case "b":
                        case "k":
                        case "s":
                            result = 2;
                            break;
                        case "c":
                        case "l":
                        case "t":
                            result = 3;
                            break;
                        case "d":
                        case "m":
                        case "u":
                            result = 4;
                            break;
                        case "e":
                        case "n":
                        case "v":
                            result = 5;
                            break;
                        case "f":
                        case "w":
                            result = 6;
                            break;
                        case "g":
                        case "p":
                        case "x":
                            result = 7;
                            break;
                        case "h":
                        case "y":
                            result = 8;
                            break;
                        case "r":
                        case "z":
                            result = 9;
                            break;
                    }
                }

                if (index >= 1 && index <= 7 || index == 9)
                    weight = 9 - index;
                else if (index == 8)
                    weight = 10;
                else if (index >= 10 && index <= 17)
                    weight = 19 - index;
                if (index == 9)
                    checkDigit = character == "x" ? 10 : result;
                checkSum += (result * weight);
            }

            return checkSum % 11 == checkDigit;
        }

        public static string GetVINCountry(string vin)
        {
            if (vin[0] >= 'A' && vin[0] <= 'H')
            {
                if (vin[0] == 'A' && vin[1] >= 'A' && vin[1] <= 'H') return "UAR";
                else if (vin[0] == 'A' && vin[1] >= 'J' && vin[1] <= 'N') return "Kot-d'Iavyar";
                else if (vin[0] == 'B' && vin[1] >= 'A' && vin[1] <= 'E') return "Angola";
                else if (vin[0] == 'B' && vin[1] >= 'F' && vin[1] <= 'K') return "Kenya";
                else if (vin[0] == 'B' && vin[1] >= 'L' && vin[1] <= 'R') return "Tanzanya";
                else if (vin[0] == 'C' && vin[1] >= 'A' && vin[1] <= 'E') return "Benin";
                else if (vin[0] == 'C' && vin[1] >= 'F' && vin[1] <= 'K') return "Madagaskar";
                else if (vin[0] == 'C' && vin[1] >= 'L' && vin[1] <= 'R') return "Tynis";
                else if (vin[0] == 'D' && vin[1] >= 'A' && vin[1] <= 'E') return "Egypt";
                else if (vin[0] == 'D' && vin[1] >= 'F' && vin[1] <= 'K') return "Morokko";
                else if (vin[0] == 'D' && vin[1] >= 'L' && vin[1] <= 'R') return "Zambiya";
                else if (vin[0] == 'E' && vin[1] >= 'A' && vin[1] <= 'E') return "Efiopiya";
                else if (vin[0] == 'E' && vin[1] >= 'F' && vin[1] <= 'K') return "Mozambik";
                else if (vin[0] == 'F' && vin[1] >= 'A' && vin[1] <= 'E') return "Gana";
                else if (vin[0] == 'F' && vin[1] >= 'F' && vin[1] <= 'K') return "Nigerya";
                else return "Ne ispolzyetsya";
            }
            else if (vin[0] >= 'J' && vin[0] <= 'R')
            {
                if (vin[0] == 'J' && vin[1] >= 'A' && vin[1] <= 'T') return "Japan";
                else if (vin[0] == 'K' && vin[1] >= 'A' && vin[1] <= 'E') return "Shri Lanka";
                else if (vin[0] == 'K' && vin[1] >= 'F' && vin[1] <= 'K') return "Izrael";
                else if (vin[0] == 'K' && vin[1] >= 'L' && vin[1] <= 'R') return "South Korea";
                else if (vin[0] == 'K' && vin[1] >= 'S' && vin[1] <= 'Z' || vin[1] == '0') return "Kazahstan";
                else if (vin[0] == 'L' && vin[1] >= 'A' && vin[1] <= 'Z' || vin[1] == '0') return "China";
                else if (vin[0] == 'M' && vin[1] >= 'A' && vin[1] <= 'E') return "Indiya";
                else if (vin[0] == 'M' && vin[1] >= 'F' && vin[1] <= 'K') return "Indoneziya";
                else if (vin[0] == 'M' && vin[1] >= 'L' && vin[1] <= 'R') return "Thailand";
                else if (vin[0] == 'N' && vin[1] >= 'F' && vin[1] <= 'K') return "Pakistan";
                else if (vin[0] == 'N' && vin[1] >= 'L' && vin[1] <= 'R') return "Turkey";
                else if (vin[0] == 'P' && vin[1] >= 'A' && vin[1] <= 'E') return "Philipes";
                else if (vin[0] == 'P' && vin[1] >= 'F' && vin[1] <= 'K') return "Singapour";
                else if (vin[0] == 'P' && vin[1] >= 'L' && vin[1] <= 'R') return "Malasiya";
                else if (vin[0] == 'R' && vin[1] >= 'A' && vin[1] <= 'E') return "OAE";
                else if (vin[0] == 'R' && vin[1] >= 'F' && vin[1] <= 'K') return "Taivan";
                else if (vin[0] == 'R' && vin[1] >= 'L' && vin[1] <= 'R') return "Vietnam";
                else if (vin[0] == 'R' && vin[1] >= 'S' && vin[1] <= 'Z' || vin[1] == '0') return "Saudi Arabia";
                else return "Ne ispolzyetsya";
            }
            else if(vin[0] >= 'S' && vin[0] <= 'Z')
            {
                if (vin[0] == 'S' && vin[1] >= 'A' && vin[1] <= 'M') return "Great Britan";
                else if (vin[0] == 'S' && vin[1] >= 'N' && vin[1] <= 'T') return "Germany";
                else if (vin[0] == 'S' && vin[1] >= 'U' && vin[1] <= 'Z') return "Poland";
                else if (vin[0] == 'S' && vin[1] >= '1' && vin[1] <= '4') return "Latviya";
                else if (vin[0] == 'T' && vin[1] >= 'A' && vin[1] <= 'H') return "Shwitezland";
                else if (vin[0] == 'T' && vin[1] >= 'J' && vin[1] <= 'P') return "Chehiya";
                else if (vin[0] == 'T' && vin[1] >= 'R' && vin[1] <= 'V') return "Venriya";
                else if (vin[0] == 'T' && vin[1] >= 'W' && vin[1] <= 'Z' || vin[1] == '0' || vin[1] == '1') return "Portugal";
                else if (vin[0] == 'U' && vin[1] >= 'H' && vin[1] <= 'M') return "Daniya";
                else if (vin[0] == 'U' && vin[1] >= 'N' && vin[1] <= 'T') return "Ireland";
                else if (vin[0] == 'U' && vin[1] >= 'U' && vin[1] <= 'Z') return "Romania";
                else if (vin[0] == 'U' && vin[1] >= '5' && vin[1] <= '7') return "Slovakia";
                else if (vin[0] == 'V' && vin[1] >= 'A' && vin[1] <= 'E') return "Avsriya";
                else if (vin[0] == 'V' && vin[1] >= 'F' && vin[1] <= 'R') return "France";
                else if (vin[0] == 'V' && vin[1] >= 'S' && vin[1] <= 'W') return "Spain";
                else if (vin[0] == 'V' && vin[1] == 'X' || vin[1] >= '1' && vin[1] <= '2') return "Serbiya";
                else if (vin[0] == 'V' && vin[1] >= '3' && vin[1] <= '5') return "Horvatia";
                else if (vin[0] == 'V' && vin[1] >= '6' && vin[1] <= '9' || vin[1] == '0') return "Estony";
                else if (vin[0] == 'W' && vin[1] >= 'A' && vin[1] <= 'Z' || vin[1] == '0') return "Germany";
                else if (vin[0] == 'X' && vin[1] >= 'A' && vin[1] <= 'E') return "Bolgary";
                else if (vin[0] == 'X' && vin[1] >= 'F' && vin[1] <= 'K') return "Greece";
                else if (vin[0] == 'X' && vin[1] >= 'L' && vin[1] <= 'R') return "Netherlands";
                else if (vin[0] == 'X' && vin[1] >= 'S' && vin[1] <= 'W') return "USSR/SNG";
                else if (vin[0] == 'X' && vin[1] >= 'X' || vin[1] >= '1' && vin[1] <= '2') return "Luxembourg";
                else if (vin[0] == 'X' && vin[1] >= '3' && vin[1] <= '9' || vin[1] == '0' || vin[0] == 'Z' && vin[1] >= '6' && vin[1] <= '9' || vin[1] == '0') return "Russia";
                else if (vin[0] == 'Y' && vin[1] >= 'A' && vin[1] <= 'E') return "Belgya";
                else if (vin[0] == 'Y' && vin[1] >= 'F' && vin[1] <= 'K') return "Finland";
                else if (vin[0] == 'Y' && vin[1] >= 'L' && vin[1] <= 'R') return "Malta";
                else if (vin[0] == 'Y' && vin[1] >= 'S' && vin[1] <= 'W') return "Shweden";
                else if (vin[0] == 'Y' && vin[1] >= 'X' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '2') return "Norvegya";
                else if (vin[0] == 'Y' && vin[1] >= '3' && vin[1] <= '5') return "Bella";
                else if (vin[0] == 'Y' && vin[1] >= '6' && vin[1] <= '9' || vin[1] == '0') return "Ukraine";
                else if (vin[0] == 'Z' && vin[1] >= 'A' && vin[1] <= 'R') return "Italy";
                else if (vin[0] == 'Z' && vin[1] >= 'X' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '2') return "Sloveny";
                else if (vin[0] == 'Z' && vin[1] >= '3' && vin[1] <= '5') return "Litva";
                else return "Ne ispolzyetsya";
            }
            else if(vin[0] >= '1' && vin[0] <= '5')
            {
                if (vin[0] == '1' && vin[1] >= 'A' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '9' || vin[1] == '0' || vin[0] == '4' && vin[1] >= 'A' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '9' || vin[1] == '0' || vin[0] == '5' && vin[1] >= 'A' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '9' || vin[1] == '0') return "USA";
                else if (vin[0] == '2' && vin[1] >= 'A' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '9' || vin[1] == '0') return "Kanada";
                else if (vin[0] == '3' && vin[1] >= 'A' && vin[1] <= 'W') return "Mexiko";
                else if (vin[0] == '3' && vin[1] >= 'X' && vin[1] <= 'Z' || vin[1] >= '1' && vin[1] <= '7') return "Kosta-Riko";
                else if (vin[0] == '3' && vin[1] >= '8' && vin[1] <= '9' || vin[1] == '0') return "Kayman Islands";
                else return "Ne ispolzyetsya";
            }
            else if(vin[0] >= '6' && vin[0] <= '7')
            {
                if (vin[0] == '6' && vin[1] >= 'A' && vin[1] <= 'W') return "Avstraliya";
                else if (vin[0] == '7' && vin[1] >= 'A' && vin[1] <= 'E') return "New Zelandya";
                else return "Ne ispolzyetsya";
            }
            else if(vin[0] >= '8' && vin[0] <= '9')
            {
                if (vin[0] == '8' && vin[1] >= 'A' && vin[1] <= 'E') return "Argentina";
                else if (vin[0] == '8' && vin[1] >= 'F' && vin[1] <= 'K') return "Chily";
                else if (vin[1] == '8' && vin[1] >= 'L' && vin[1] <= 'R') return "Ekvador";
                else if (vin[1] == '8' && vin[1] >= 'S' && vin[1] <= 'W') return "Peruvain";
                else if (vin[0] == '8' && vin[1] >= 'X' && vin[1] <= 'X' || vin[1] >= '1' && vin[1] <= '2') return "Venezuela";
                else if (vin[0] == '9' && vin[1] >= 'A' && vin[1] <= 'E' || vin[0] == '9' && vin[1] >= '3' && vin[1] <= '9') return "Brazilya";
                else if (vin[0] == '9' && vin[1] >= 'F' && vin[1] <= 'K') return "Kolumbya";
                else if (vin[0] == '9' && vin[1] >= 'L' && vin[1] <= 'R') return "Paraguay";
                else if (vin[0] == '9' && vin[1] >= 'S' && vin[1] <= 'W') return "Uruguay";
                else if (vin[0] == '9' && vin[1] >= 'X' && vin[1] <= 'Y' || vin[1] >= '1' && vin[1] <= '2') return "Trinidad and Tobago";
                else return "Ne ispolzyetsya";
            }
            return "";
        }

        public static int GetTransporYear(string vin)
        {
            Dictionary<string, int> years = new Dictionary<string, int>();
            years["A"] = 1980;
            years["B"] = 1981;
            years["C"] = 1982;
            years["D"] = 1983;
            years["E"] = 1984;
            years["F"] = 1985;
            years["G"] = 1986;
            years["H"] = 1987;
            years["J"] = 1988; 
            years["K"] = 1989;
            years["L"] = 1990;
            years["M"] = 1991;
            years["N"] = 1992;
            years["P"] = 1993;
            years["R"] = 1994;
            years["S"] = 1995;
            years["T"] = 1996;
            years["V"] = 1997;
            years["W"] = 1998;
            years["X"] = 1999;
            years["Y"] = 2000;
            years["1"] = 2001;
            years["2"] = 2002;
            years["3"] = 2003;
            years["4"] = 2004;
            years["5"] = 2005;
            years["6"] = 2006;
            years["7"] = 2007;
            years["8"] = 2008;
            years["9"] = 2009;
            // Первая часть расшифровки года ТС.
            years["A"] = 2010;
            years["B"] = 2011;
            years["C"] = 2012;
            years["D"] = 2013;
            years["E"] = 2014;
            years["F"] = 2015;
            years["G"] = 2016;
            years["H"] = 2017;
            years["J"] = 2018;
            years["K"] = 2019;
            years["L"] = 2020;
            years["M"] = 2021;
            years["N"] = 2022;
            years["P"] = 2023;
            years["R"] = 2024;
            years["S"] = 2025;
            years["T"] = 2026;
            years["V"] = 2027;
            years["W"] = 2028;
            years["X"] = 2029;
            years["Y"] = 2030;
            years["1"] = 2031;
            years["2"] = 2032;
            years["3"] = 2033;
            years["4"] = 2034;
            years["5"] = 2035;
            years["6"] = 2036;
            years["7"] = 2037;
            years["8"] = 2038;
            years["9"] = 2039;
            // Вторая часть расшифровки года ТС.
            
            return years[vin[9].ToString()];
            
        }

       
    }
}
