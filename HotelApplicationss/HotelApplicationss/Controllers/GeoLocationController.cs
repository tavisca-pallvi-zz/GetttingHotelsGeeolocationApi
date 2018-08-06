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

        [Route("api/GeoLocation/{add}")]
        public List<string> GetAddress(string add)
        {

            Address address = new Address();
            var location = new GoogleLocationService();
            var Location = location.GetLatLongFromAddress(add);
            address.latitude = Location.Latitude;
            address.longitude = Location.Longitude;
            string ur = "https://maps.googleapis.com/maps/api/place/autocomplete/xml?input=" + add + "&types=geocode&language=en&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI";

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ur);

            XmlNodeList elementList = xmldoc.GetElementsByTagName("description");
            string str = elementList[0].InnerXml;
          /*  StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(elementList);
            xmldoc.WriteTo(tx);

            string str = sw.ToString();
    */        
            address.add = str; 
            double radius = 20;
            return (HotelController.GetHotelsInfo(address.add, address.latitude, address.longitude));
        }//funcrio

      

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
