using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplicationss.Models;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml;
//using JavaScriptSerializer;

namespace HotelApplicationss.Controllers
{

    public class HotelController : ApiController
    {
        public static List<string>GetHotelsInfo([FromUri]string name,double latitude,double longitude) {
            int c = 3;
            string lat = latitude.ToString();
            string lon = longitude.ToString();
            string line = null;
            List<string> hotel = new List<string>();
            // string ur = "https://maps.googleapis.com/maps/api/place/autocomplete/xml?input=" + name + "&types=geocode&language=en&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI";
            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location=" + lat + "," + lon + "&radius=1500&type=hotel&keyword=cruise&key=AIzaSyAbAfnZkuWEBuneMJUafr8h2_fpvMm48is";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(url);
            XmlNodeList elementList = xmldoc.GetElementsByTagName("name");
           
            //hotel.Add(elementList[0].InnerXml);



            for (int i = 0; i < elementList.Count; i++)
            {
                hotel.Add(elementList[i].InnerXml);
            }
            
            return hotel;
        }


                /*
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(myxml);

                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                doc.WriteTo(tx);

                string str = sw.ToString();// 
                return str;
                */
                /*
                while (sLine != null)
                {
                    i++;
                    sLine = objReader.ReadLine();
                    sLine = sLine.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                    o = JObject.Parse(sLine);

                    str.Add(sLine);

                }
                */
                /* string ss = "";
                 foreach (string st:str)
                 {
                     ss=ss

                 }
                 */

                //string name = (string)o["name"];

            //return name;
        }
    }






      /*  static List<Hotel> hotel = new List<Hotel>()
        {
          new Hotel
          {
              Name="Novotel",Hotelid=1,Address="PuneNagar",Rooms=100,Airportcode="PNQ"

          },
         new Hotel
          {
              Name="Hyatt",Hotelid=2,Address="Viman NagarPune",Rooms=100,Airportcode="PNQ"

          },
         new Hotel
          {
              Name="Taj",Hotelid=3,Address="Mumbai",Rooms=100,Airportcode="BOM"},
          };

        public List<Hotel> GetHotels()
        {
            return hotel;
        }
        public  ApiResponse PostHotels(Hotel h)//
        {

            c++;
            Hotel existHotel = hotel.Find(p => p.Hotelid == c);
            if (existHotel != null)
            {
                return new ApiResponse{

                        errorCode = 404,
                        status = Status.Failure,
                     
                        errorMsg = "Hotel Exists",
                };
                h.Hotelid = c;
                hotel.Add(h);
            }
     

            return new ApiResponse {

                errorCode = 200,
                status = Status.Success,
                hotel = h,
                errorMsg = "Hotel Added Succesfully",

            };


        }
        [HttpPut]
        public ApiResponse BookAFlight(int id, [FromBody]int rooms)
        {

            Hotel desiredHotel = null;
            desiredHotel = hotel.Find(x => x.Hotelid == id);
            if (desiredHotel != null)
            {
                if (desiredHotel.Rooms >= rooms)
                {
                    desiredHotel.Rooms = desiredHotel.Rooms - rooms;
                    return new ApiResponse()
                    {

                        errorCode = 200,
                        status = Status.Success,
                        hotel = desiredHotel,
                        errorMsg = "Rooms available",

                      };


                }
                else
                {
                  return new ApiResponse()
                  {     errorCode = 404,
                        status = Status.Failure,
                        hotel = desiredHotel,
                        errorMsg = "Rooms not available",

            };

                }
            }

            return new ApiResponse()
            {
                errorCode = 400,
                status = Status.Failure,
                hotel = desiredHotel,
                errorMsg = "Hotel not available",
    };
        }

      //work  [Route("api/Hotel/{is}/courses/school")]
        public ApiResponse GetValueByid(int id)
        {


            Hotel desiredHotel = null;
            desiredHotel = hotel.Find(x => x.Hotelid == id);
            if (desiredHotel != null)
            {
                return new ApiResponse()
                {

                    errorCode = 200,
                    status = Status.Success,
                    hotel = desiredHotel,
                    errorMsg = "Hotel found",

            };
            }
            return new ApiResponse()
            {
                errorCode = 400,
                status = Status.Failure,
                errorMsg = "Hotel not found",

            };

        }

       // [Route("api/Hotel/{id}/courses/school")]
        public string GetNearbyPlaces ()
        {
            return "hello";
        }
        public HttpResponseMessage DeleteById([FromBody]int id)
        {
            Hotel desiredHotel = null;
            HttpResponseMessage response=null;

            response = Request.CreateResponse(HttpStatusCode.BadRequest, hotel);
          
            try
            {
                desiredHotel = hotel.Find(x => x.Hotelid == id);

                if (desiredHotel != null)
                {
                    hotel.Remove(desiredHotel);
                    response = Request.CreateResponse(HttpStatusCode.OK, hotel);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, hotel);
                    return response;

                }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(Json(ex.Message));
                }

           return response;
        }
     */
