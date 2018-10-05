//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.BaseClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Providers;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public abstract class BaseClient
  {
    protected readonly ISdkClientConfigProvider SdkClientConfigProvider;

    protected BaseClient(ISdkClientConfigProvider sdkClientConfigProvider)
    {
      this.SdkClientConfigProvider = sdkClientConfigProvider;
    }

    protected internal static async Task<ApiResponse> GetApiResponseAsync(HttpRequestMessage httpRequestMessage, ICredentials credentials, CancellationToken cancellationToken)
    {
      return (ApiResponse) await BaseClient.GetApiResponseAsync<object>(httpRequestMessage, credentials, cancellationToken);
    }

    protected internal static async Task<ApiResponse<T>> GetApiResponseAsync<T>(HttpRequestMessage httpRequestMessage, ICredentials credentials, CancellationToken cancellationToken)
    {
      using (HttpClientHandler httpClientHandler = new HttpClientHandler())
      {
        int num = 0;
        if ((uint) num > 1U && credentials != null)
          httpClientHandler.Credentials = credentials;
        try
        {
          using (HttpClient httpClient = new HttpClient((HttpMessageHandler) httpClientHandler))
          {
            using (HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage, cancellationToken))
            {
              ApiResponse<T> apiResponse1 = new ApiResponse<T>();
              ApiResponse<T> apiResponse2 = apiResponse1;
              apiResponse2.Content = await response.Content.ReadAsStringAsync();
              apiResponse1.IsSuccessStatusCode = response.IsSuccessStatusCode;
              apiResponse1.ReasonPhrase = response.ReasonPhrase;
              apiResponse1.StatusCode = response.StatusCode;
              ApiResponse<T> apiResponse = apiResponse1;
              apiResponse2 = (ApiResponse<T>) null;
              apiResponse1 = (ApiResponse<T>) null;
              BaseClient.DeserializeContent<T>(apiResponse);
              return apiResponse;
            }
          }
        }
        catch (HttpRequestException ex)
        {
          ApiResponse<T> apiResponse = new ApiResponse<T>();
          apiResponse.StatusCode = HttpStatusCode.InternalServerError;
          apiResponse.ReasonPhrase = ex.Message;
          apiResponse.Content = ex.ToString();
          apiResponse.IsSuccessStatusCode = false;
          BaseClient.DeserializeContent<T>(apiResponse);
          return apiResponse;
        }
      }
    }

    protected internal static ApiResponse GetApiResponse(BaseClient.RequestEnvelope envelope, ICredentials credentials)
    {
      return (ApiResponse) BaseClient.GetApiResponse<object>(envelope, credentials);
    }

    protected internal static ApiResponse<T> GetApiResponse<T>(BaseClient.RequestEnvelope envelope, ICredentials credentials)
    {
      if (envelope.Exception != null)
      {
        ApiResponse<T> apiResponse = new ApiResponse<T>();
        apiResponse.StatusCode = HttpStatusCode.InternalServerError;
        apiResponse.ReasonPhrase = envelope.Exception.Message;
        apiResponse.Content = envelope.Exception.ToString();
        apiResponse.IsSuccessStatusCode = false;
        return apiResponse;
      }
      if (credentials != null)
        envelope.Request.Credentials = credentials;
      try
      {
        using (HttpWebResponse response = (HttpWebResponse) envelope.Request.GetResponse())
          return BaseClient.GetApiResponse<T>(response);
      }
      catch (WebException ex)
      {
        using (HttpWebResponse response = (HttpWebResponse) ex.Response)
          return BaseClient.GetApiResponse<T>(response);
      }
    }

    protected internal static ApiResponse<T> GetApiResponse<T>(HttpWebResponse response)
    {
      ApiResponse<T> apiResponse1 = new ApiResponse<T>();
      apiResponse1.StatusCode = response.StatusCode;
      apiResponse1.ReasonPhrase = response.StatusDescription;
      apiResponse1.IsSuccessStatusCode = response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.MultipleChoices;
      ApiResponse<T> apiResponse2 = apiResponse1;
      using (Stream responseStream = response.GetResponseStream())
      {
        if (responseStream != null)
        {
          using (StreamReader streamReader = new StreamReader(responseStream))
            apiResponse2.Content = streamReader.ReadToEnd();
        }
      }
      BaseClient.DeserializeContent<T>(apiResponse2);
      return apiResponse2;
    }

    protected internal static void DeserializeContent<T>(ApiResponse<T> apiResponse)
    {
      try
      {
        if (!apiResponse.IsSuccessStatusCode)
          return;
        apiResponse.Model = JsonConvert.DeserializeObject<T>(apiResponse.Content);
      }
      catch (Exception ex)
      {
        throw new Exception(apiResponse.Content, ex);
      }
    }

    protected internal static HttpRequestMessage GetHttpRequestMessage(Uri uri, HttpMethod method, HttpRequestHeaders headers, string bearerToken, HttpContent content = null)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri);
      if (headers != null)
      {
        foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) headers)
          httpRequestMessage.Headers.Add(header.Key, header.Value);
      }
      if (!string.IsNullOrWhiteSpace(bearerToken))
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
      if (content != null)
        httpRequestMessage.Content = content;
      return httpRequestMessage;
    }

    protected internal static FormUrlEncodedContent GetFormUrlEncodedContent(IDictionary<string, string> data)
    {
      return new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>) data);
    }

    protected internal static StringContent GetJsonContent<T>(T model)
    {
      return new StringContent(JsonConvert.SerializeObject((object) model), Encoding.UTF8, "application/json");
    }

    protected internal static byte[] GetJsonBytes<T>(T model)
    {
      return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) model));
    }

    internal static BaseClient.RequestEnvelope GetHttpWebRequest(Uri uri, HttpMethod method, HttpRequestHeaders headers, string bearerToken, byte[] content = null, string contentType = "application/json")
    {
      BaseClient.RequestEnvelope requestEnvelope = new BaseClient.RequestEnvelope()
      {
        Request = (HttpWebRequest) WebRequest.Create(uri)
      };
      requestEnvelope.Request.Method = method.Method;
      if (headers != null)
      {
        foreach (KeyValuePair<string, IEnumerable<string>> header in (HttpHeaders) headers)
          requestEnvelope.Request.Headers.Add(header.Key, string.Join(",", header.Value));
      }
      if (!string.IsNullOrWhiteSpace(bearerToken))
        requestEnvelope.Request.Headers[HttpRequestHeader.Authorization] = string.Format("bearer {0}", (object) bearerToken);
      if (content != null)
      {
        requestEnvelope.Request.ContentLength = (long) content.Length;
        requestEnvelope.Request.ContentType = contentType;
        try
        {
          requestEnvelope.Request.GetRequestStream().Write(content, 0, content.Length);
        }
        catch (Exception ex)
        {
          requestEnvelope.Exception = ex;
        }
      }
      return requestEnvelope;
    }

    public static IEnumerable<KeyValuePair<string, string>> GetAllKeyValuePairs<T>(T model)
    {
      if ((object) model == null)
        return (IEnumerable<KeyValuePair<string, string>>) null;
      return BaseClient.GetModelKeyValuePairs<T>(model, (string) null);
    }

    public static IEnumerable<KeyValuePair<string, string>> GetModelKeyValuePairs<T>(T model, string parent = null)
    {
      Validator.ValidateObject((object) (T) model, new ValidationContext((object) (T) model), true);
      bool hasParent = !string.IsNullOrWhiteSpace(parent);
      PropertyInfo[] propertyInfoArray = model.GetType().GetProperties();
      for (int index = 0; index < propertyInfoArray.Length; ++index)
      {
        PropertyInfo element = propertyInfoArray[index];
        if (!element.GetCustomAttributes().ToList<Attribute>().OfType<JsonIgnoreAttribute>().Any<JsonIgnoreAttribute>())
        {
          object propertyValue = element.GetValue((object) (T) model);
          if (propertyValue != null)
          {
            string name = element.Name;
            string key = hasParent ? string.Format("{0}.{1}", (object) parent, (object) name) : name;
            if (BaseClient.Traverse(element.PropertyType))
            {
              IEnumerable enumerable = propertyValue as IEnumerable;
              if (enumerable != null)
              {
                int i = 0;
                foreach (object obj in enumerable)
                {
                  object item = obj;
                  string keyi = string.Format("{0}[{1}]", (object) key, (object) i);
                  if (BaseClient.Traverse(item.GetType()))
                  {
                    foreach (KeyValuePair<string, string> modelKeyValuePair in BaseClient.GetModelKeyValuePairs<object>(item, keyi))
                      yield return modelKeyValuePair;
                  }
                  else
                    yield return new KeyValuePair<string, string>(keyi, item.ToString());
                  ++i;
                  keyi = (string) null;
                  item = (object) null;
                }
              }
              else
              {
                foreach (KeyValuePair<string, string> modelKeyValuePair in BaseClient.GetModelKeyValuePairs<object>(propertyValue, key))
                  yield return modelKeyValuePair;
              }
            }
            else
            {
              yield return new KeyValuePair<string, string>(key, propertyValue.ToString());
              propertyValue = (object) null;
              key = (string) null;
            }
          }
        }
      }
      propertyInfoArray = (PropertyInfo[]) null;
    }

    public static bool Traverse(Type type)
    {
      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
        type = (Type) Nullable.GetUnderlyingType(type).GetTypeInfo();
      if (!(type == (Type) null) && !type.IsNotPublic && (!type.IsPointer && !type.IsPrimitive) && (!typeof (Action<>).IsAssignableFrom(type) && !typeof (bool).IsAssignableFrom(type) && (!typeof (byte).IsAssignableFrom(type) && !typeof (byte[]).IsAssignableFrom(type))) && (!typeof (char).IsAssignableFrom(type) && !typeof (char[]).IsAssignableFrom(type) && (!typeof (DateTime).IsAssignableFrom(type) && !typeof (DBNull).IsAssignableFrom(type)) && (!typeof (Decimal).IsAssignableFrom(type) && !typeof (double).IsAssignableFrom(type) && (!typeof (Exception).IsAssignableFrom(type) && !typeof (float).IsAssignableFrom(type)))) && (!typeof (Func<>).IsAssignableFrom(type) && !typeof (Guid).IsAssignableFrom(type) && (!typeof (int).IsAssignableFrom(type) && !typeof (long).IsAssignableFrom(type)) && (!typeof (MulticastDelegate).IsAssignableFrom(type) && !typeof (sbyte).IsAssignableFrom(type) && (!typeof (short).IsAssignableFrom(type) && !typeof (string).IsAssignableFrom(type))) && (!typeof (Task).IsAssignableFrom(type) && !typeof (Type).IsAssignableFrom(type) && (!typeof (uint).IsAssignableFrom(type) && !typeof (ulong).IsAssignableFrom(type)) && !typeof (ushort).IsAssignableFrom(type))))
        return !typeof (void).IsAssignableFrom(type);
      return false;
    }

    public static string GetFormUrlEncodedString(List<KeyValuePair<string, string>> elements)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<string, string> element in elements)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append('&');
        stringBuilder.Append(BaseClient.Encode(element.Key)).Append('=').Append(BaseClient.Encode(element.Value));
      }
      return stringBuilder.ToString();
    }

    public static byte[] GetFormUrlEncodedBytes(List<KeyValuePair<string, string>> elements)
    {
      return Encoding.UTF8.GetBytes(BaseClient.GetFormUrlEncodedString(elements));
    }

    public static string Encode(string data)
    {
      if (!string.IsNullOrEmpty(data))
        return Uri.EscapeDataString(data).Replace("%20", "+");
      return string.Empty;
    }

    public Uri GetUri(string urlPath)
    {
      return this.GetUri<object>(urlPath, (object) null);
    }

    public Uri GetUri<T>(string urlPath, T model)
    {
      UriBuilder uriBuilder = new UriBuilder(this.SdkClientConfigProvider.LoadEndpoint());
      uriBuilder.Path = string.Format("{0}/{1}", (object) uriBuilder.Path.Trim('/'), (object) urlPath.Trim('/'));
      if ((object) model == null)
        return uriBuilder.Uri;
      List<KeyValuePair<string, string>> list = BaseClient.GetAllKeyValuePairs<T>(model).ToList<KeyValuePair<string, string>>();
      if (!list.Any<KeyValuePair<string, string>>())
        return uriBuilder.Uri;
      uriBuilder.Query = BaseClient.GetFormUrlEncodedString(list);
      return uriBuilder.Uri;
    }

    public class RequestEnvelope
    {
      public HttpWebRequest Request { get; set; }

      public Exception Exception { get; set; }
    }
  }
}
