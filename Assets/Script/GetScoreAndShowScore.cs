using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Compilation;
using UnityEditor.PackageManager;
using UnityEngine;

public class GetScoreAndShowScore : MonoBehaviour
{
    public class HttpClientHelper
    {
        private static readonly string WebApiUrl = "http://192.168.86.1/";

        private static string UrlAddScore = WebApiUrl + "api/User/AddUser";

        private static string medaiType = "application/json";


        public static async Task<bool> AddScore(UserInfo userInfo)
        {
            try
            {
                if (userInfo == null)
                {
                    return false;
                }
                var data = JsonConvert.SerializeObject(userInfo);
                StringContent requestBody = new StringContent(data, Encoding.UTF8, medaiType);

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
            public UserInfo(int id = 0, int score = 0, int minute = 0, float second = 0)
            {
                Id = id;
                Score = score;
                Minute = minute;
                Second = second;
            }

            public int Id { get; set; }
            public int Score { get; set; }
            public int Minute { get; set; }
            public float Second { get; set; }
        }




    }
}
