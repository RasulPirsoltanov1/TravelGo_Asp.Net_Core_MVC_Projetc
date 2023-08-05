using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date=2023-09-27&dest_type=city&units=metric&checkout_date=2023-09-28&adults_number=2&order_by=popularity&dest_id=-553173&filter_by_currency=AZN&locale=en-gb&room_number=1&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&include_adjacency=true"),
                Headers =
    {
        { "X-RapidAPI-Key", "8a0b4388afmsh7ff887cca690cdep151b55jsnbca9dc528df8" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<Root23>(body));
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetCityByName([FromQuery] string city = "baku")
        {
            string city_id = await GetCityId(city);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date=2023-09-27&dest_type=city&units=metric&checkout_date=2023-09-28&adults_number=2&order_by=popularity&dest_id={city_id}&filter_by_currency=AZN&locale=en-gb&room_number=1&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&include_adjacency=true"),
                Headers =
    {
        { "X-RapidAPI-Key", "8a0b4388afmsh7ff887cca690cdep151b55jsnbca9dc528df8" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<Root23>(body));
            }
        }

        public async Task<string> GetCityId(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={city}&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "8a0b4388afmsh7ff887cca690cdep151b55jsnbca9dc528df8" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RootCity>>(body)[0].dest_id;
            }
        }


    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AllInclusiveAmount
    {
        public double value { get; set; }
        public string currency { get; set; }
    }
    public class RootCity
    {
        public string dest_id { get; set; }
    }
    public class Amount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Badge
    {
        public string id { get; set; }
        public string badge_variant { get; set; }
        public string text { get; set; }
    }

    public class Base
    {
        public double base_amount { get; set; }
        public string kind { get; set; }
        public double? percentage { get; set; }
    }

    public class Benefit
    {
        public object icon { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public string identifier { get; set; }
        public string badge_variant { get; set; }
        public string details { get; set; }
    }

    public class BookingHome
    {
        public string group { get; set; }
        public double quality_class { get; set; }
        public string is_single_unit_property { get; set; }
        public double is_booking_home { get; set; }
        public double segment { get; set; }
    }

    public class Bwallet
    {
        public double hotel_eligibility { get; set; }
    }

    public class ChargesDetails
    {
        public Amount amount { get; set; }
        public string mode { get; set; }
        public string translated_copy { get; set; }
    }

    public class Checkin
    {
        public string from { get; set; }
        public string until { get; set; }
    }

    public class Checkout
    {
        public string from { get; set; }
        public string until { get; set; }
    }

    public class CompositePriceBreakdown
    {
        public ChargesDetails charges_details { get; set; }
        public ExcludedAmount excluded_amount { get; set; }
        public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
        public List<Item> items { get; set; }
        public List<ProductPriceBreakdown> product_price_breakdowns { get; set; }
        public List<Benefit> benefits { get; set; }
        public AllInclusiveAmount all_inclusive_amount { get; set; }
        public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
        public GrossAmount gross_amount { get; set; }
        public GrossAmountPerNight gross_amount_per_night { get; set; }
        public NetAmount net_amount { get; set; }
        public DiscountedAmount discounted_amount { get; set; }
        public StrikethroughAmount strikethrough_amount { get; set; }
        public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
    }

    public class DiscountedAmount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Distance
    {
        public string icon_name { get; set; }
        public object icon_set { get; set; }
        public string text { get; set; }
    }

    public class ExcludedAmount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class ExternalReviews
    {
        public double score { get; set; }
        public string score_word { get; set; }
        public double num_reviews { get; set; }
        public string should_display { get; set; }
    }

    public class GrossAmount
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class GrossAmountHotelCurrency
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class GrossAmountPerNight
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class IncludedTaxesAndChargesAmount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Item
    {
        public string inclusion_type { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public string details { get; set; }
        public ItemAmount item_amount { get; set; }
        public Base @base { get; set; }
        public string identifier { get; set; }
    }

    public class ItemAmount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class MapBoundingBox
    {
        public double ne_lat { get; set; }
        public double sw_lat { get; set; }
        public double ne_long { get; set; }
        public double sw_long { get; set; }
    }

    public class MatchingUnitsCommonConfig
    {
        public double unit_type_id { get; set; }
        public string localized_area { get; set; }
    }

    public class MatchingUnitsConfiguration
    {
        public MatchingUnitsCommonConfig matching_units_common_config { get; set; }
    }

    public class NetAmount
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class PriceBreakdown
    {
        public double has_fine_prdouble_charges { get; set; }
        public double has_incalculable_charges { get; set; }
        public double has_tax_exceptions { get; set; }
        public object gross_price { get; set; }
        public string currency { get; set; }
        public string sum_excluded_raw { get; set; }
        public double all_inclusive_price { get; set; }
    }

    public class ProductPriceBreakdown
    {
        public AllInclusiveAmount all_inclusive_amount { get; set; }
        public List<Benefit> benefits { get; set; }
        public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
        public GrossAmount gross_amount { get; set; }
        public NetAmount net_amount { get; set; }
        public GrossAmountPerNight gross_amount_per_night { get; set; }
        public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
        public ChargesDetails charges_details { get; set; }
        public ExcludedAmount excluded_amount { get; set; }
        public List<Item> items { get; set; }
        public StrikethroughAmount strikethrough_amount { get; set; }
        public DiscountedAmount discounted_amount { get; set; }
        public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string type { get; set; }
        public string zip { get; set; }
        public string cc1 { get; set; }
        public double ufi { get; set; }
        public double accommodation_type { get; set; }
        public string default_wishlist_name { get; set; }
        public double soldout { get; set; }
        public string hotel_name_trans { get; set; }
        public double children_not_allowed { get; set; }
        public string ribbon_text { get; set; }
        public string native_ads_tracking { get; set; }
        public List<Distance> distances { get; set; }
        public double is_smart_deal { get; set; }
        public double is_beach_front { get; set; }
        public Checkin checkin { get; set; }
        public double is_no_prepayment_block { get; set; }
        public string countrycode { get; set; }
        public object updated_checkout { get; set; }
        public double hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string unit_configuration_label { get; set; }
        public object selected_review_topic { get; set; }
        public double cant_book { get; set; }
        public double price_is_final { get; set; }
        public string distance { get; set; }
        public string url { get; set; }
        public double preferred { get; set; }
        public string accommodation_type_name { get; set; }
        public CompositePriceBreakdown composite_price_breakdown { get; set; }
        public string country_trans { get; set; }
        public double is_city_center { get; set; }
        public string distance_to_cc { get; set; }
        public double native_ads_cpc { get; set; }
        public object is_geo_rate { get; set; }
        public string address { get; set; }
        public double in_best_district { get; set; }
        public List<Badge> badges { get; set; }
        public object updated_checkin { get; set; }
        public double is_mobile_deal { get; set; }
        public double genius_discount_percentage { get; set; }
        public double min_total_price { get; set; }
        public double main_photo_id { get; set; }
        public double @class { get; set; }
        public double longitude { get; set; }
        public double mobile_discount_percentage { get; set; }
        public double review_nr { get; set; }
        public double cc_required { get; set; }
        public string currency_code { get; set; }
        public string default_language { get; set; }
        public double wishlist_count { get; set; }
        public string city_name_en { get; set; }
        public double district_id { get; set; }
        public string districts { get; set; }
        public Bwallet bwallet { get; set; }
        public MatchingUnitsConfiguration matching_units_configuration { get; set; }
        public string city { get; set; }
        public double is_genius_deal { get; set; }
        public string timezone { get; set; }
        public double preferred_plus { get; set; }
        public string city_trans { get; set; }
        public string distance_to_cc_formatted { get; set; }
        public double class_is_estimated { get; set; }
        public string review_score_word { get; set; }
        public double latitude { get; set; }
        public string currencycode { get; set; }
        public string main_photo_url { get; set; }
        public List<string> block_ids { get; set; }
        public double extended { get; set; }
        public double is_free_cancellable { get; set; }
        public string native_ad_id { get; set; }
        public double? review_score { get; set; }
        public PriceBreakdown price_breakdown { get; set; }
        public double hotel_has_vb_boost { get; set; }
        public string review_recommendation { get; set; }
        public string address_trans { get; set; }
        public string city_in_trans { get; set; }
        public string district { get; set; }
        public Checkout checkout { get; set; }
        public string hotel_facilities { get; set; }
        public string max_photo_url { get; set; }
        public string max_1440_photo_url { get; set; }
        public double? hotel_include_breakfast { get; set; }
        public double? has_free_parking { get; set; }
        public ExternalReviews external_reviews { get; set; }
        public BookingHome booking_home { get; set; }
    }

    public class RoomDistribution
    {
        public List<double> children { get; set; }
        public string adults { get; set; }
    }

    public class Root23
    {
        public double primary_count { get; set; }
        public double count { get; set; }
        public List<RoomDistribution> room_distribution { get; set; }
        public MapBoundingBox map_bounding_box { get; set; }
        public double total_count_with_filters { get; set; }
        public double unfiltered_count { get; set; }
        public double extended_count { get; set; }
        public double unfiltered_primary_count { get; set; }
        public double search_radius { get; set; }
        public List<Sort> sort { get; set; }
        public List<Result> result { get; set; }
    }

    public class Sort
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class StrikethroughAmount
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class StrikethroughAmountPerNight
    {
        public double value { get; set; }
        public string currency { get; set; }
    }


}
