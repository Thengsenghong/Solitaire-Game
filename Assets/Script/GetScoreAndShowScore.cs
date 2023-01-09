using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GetScoreAndShowScore : MonoBehaviour
{

    public class HttpClientHelper
    {
        private static readonly string WebApiUrl = "http://192.168.1.26/";

        private static string UrlAddScore = WebApiUrl + "api/User/AddUser";
        private static string UrlGetScore = WebApiUrl + "api/User/GetUser";

        private static string mediaType = "application/json";


        public static async Task<bool> AddScore(UserInfo userInfo)
        {
            try
            {
                if (userInfo == null)
                {
                    return false;
                }
                var data = JsonConvert.SerializeObject(userInfo);
                StringContent requestBody = new StringContent(data, Encoding.UTF8, mediaType);

                HttpClient httpClient = new HttpClient();
                using var res = await httpClient.PostAsync(UrlAddScore, requestBody);
                if (res.IsSuccessStatusCode)
                {
                    var content = await res.Content.ReadAsStringAsync();
                    UnityEngine.Debug.Log(content);
                    if (!string.IsNullOrEmpty(content))
                    {
                        var resultData = JsonConvert.DeserializeObject<ResponseObject<Boolean?>>(content);
                        if (resultData != null)
                        {
                            return resultData.IsSuccess;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            return false;
        }
        public enum ErrorCode
        {
            Success =0,
            Exception = 500,
            InvalidRequest= 400

        }
        public class ResponseObject<T>
        {
            public ErrorCode ErrorCode { get; set; }
            public string Message { get; set; }
            public bool IsSuccess { get; set; }
            public T Data { get; set; }

            public ResponseObject(bool isSuccess, ErrorCode errorCode, string message, T data = default)
            {
                ErrorCode = errorCode;
                Message = message;
                IsSuccess = isSuccess;
                Data = data;
            }
        }

        public class UserInfo
        {
            public UserInfo(int id = 0, string name ="", int score = 0, int minute = 0, float second = 0)
            {
                Id = id;
                Name= name;
                Score = score;
                Minute = minute;
                Second = second;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public int Score { get; set; }
            public int Minute { get; set; }
            public float Second { get; set; }
        }
        public static async Task<List<UserInfo>> GetScore()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                using var res = await client.GetAsync(UrlGetScore);
                if (res.IsSuccessStatusCode)
                {
                    var content = await res.Content.ReadAsStringAsync();
                    Debug.Log(content);
                    if (!string.IsNullOrEmpty(content))
                    {
                        var data = JsonConvert.DeserializeObject<List<UserInfo>>(content);
                        Debug.Log(data[0].ToString());
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            return new List<UserInfo>();
        }



    }

}

