using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using GoogleMaps;
using GoogleMaps.LocationServices;
using HotelApplicationss.Models;


namespace HotelApplicationss.Controllers
{
    public class GeoLocationController : ApiController
    {


        /*    public Address  PostAddress([FromBody]Address addr)
            {

                Address address = new Address();
                address.add = addr.add;
                var location = new GoogleLocationService();
                var Location = location.GetLatLongFromAddress(address.add);
                address.latitude = Location.Latitude;
                address.longitude= Location.Longitude;

                return address;
            }
            */
//hoo aascascasxc
        [Route("api/GeoLocation/{add}")]
        public void GetAddress(string add)
        {
            var location = new GoogleLocationService();
            string ur = "https://maps.googleapis.com/maps/api/place/autocomplete/xml?input=" + add + "&types=geocode&language=en&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI";

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ur);
            List<Address> lst = new List<Address>();
            XmlNodeList elementList = xmldoc.GetElementsByTagName("description");
           
           for(int i=0;i<3; i++)
            {
                Address address = new Address();
                string str = elementList[i].InnerXml;
                var Location = location.GetLatLongFromAddress(str);
                address.latitude = Location.Latitude;
                address.longitude = Location.Longitude;
                address.add = str;


                lst.Add(address);
                }

            Post(lst[0]);
            }
        public List<string> Post(Address ad)
        {
            string lat = ad.latitude.ToString();
            string lon = ad.longitude.ToString();
            string line = null;
            List<string> hotel = new List<string>();
            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location=" + lat + "," + lon + "&radius=1twsl500&type=hotel&keyword=cruise&key=AIzaSyAbAfnZkuWEBuneMJUafr8h2_fpvMm48is";
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


        // [Route("api/GeoLocation/{add}/{lat}/{long}")]
        /*  public List<Address> Post(string add, double latitude, double longitude)
          {

              XmlDocument xmldoc = new XmlDocument();
              xmldoc.Load(ur);
              List<Address> lst = new List<Address>();
              XmlNodeList elementList = xmldoc.GetElementsByTagName("description");

              for (int i = 0; i < 3; i++)
              {
                  Address address = new Address();
                  string str = elementList[i].InnerXml;
                  var Location = location.GetLatLongFromAddress(str);
                  address.latitude = Location.Latitude;
                  address.longitude = Location.Longitude;
                  address.add = str;


                  lst.Add(address);
              }

              return lst;
          }
          */
        // string str = elementList[0].InnerXml;
        // 

        /* address.latitude = Location.Latitude;
         address.longitude = Location.Longitude;
         */
        /*  StringWriter sw = new StringWriter();
          XmlTextWriter tx = new XmlTextWriter(elementList);
          xmldoc.WriteTo(tx);

          string str = sw.ToString();
  */
        //  address.add = str; 
        /*double radius = 20;
        return (HotelController.GetHotelsInfo(address.add, address.latitude, address.longitude));
    */



        [Route("api/GeoLocation/{add}/{latitude}/{longitude}/{radius}")]
        public Address GetHotels(string add,double latitude,double longitude,double radius)
        {
            Address address = new Address();
            var location = new GoogleLocationService();
            var Location = location.GetLatLongFromAddress(add);
            address.latitude =latitude;
            address.longitude =longitude;
            address.add = add;
            address.radius = radius;
            return address;
        }




    }
}
