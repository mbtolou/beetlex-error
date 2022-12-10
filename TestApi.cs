using System.Security.Cryptography;
using BeetleX.FastHttpApi;

[Controller(BaseUrl = "api/test-upload/")]
class TestApi
{
	[Post]
	public object upload(IHttpContext context)
	{
		foreach (var file in context.Request.Files)
			using (var md5 = MD5.Create())
			{
				return Convert.ToHexString(md5.ComputeHash(file.Data));
			}
		return context.Request.Files.Count;
	}

}


[Controller(BaseUrl = "api/cros-test/")]
class CrosApi
{
	[Post]
	[OptionsAttribute(AllowOrigin = "www.goooogle.com")]
	public object getNowCustomOrigin(IHttpContext context)
	{
		return new { Time = DateTime.Now, Origin = context.Request.Header["Origin"] };
	}

	[Post]
	public object getNow(IHttpContext context)
	{
		return new { Time = DateTime.Now, Origin = context.Request.Header["Origin"] };
	}
}


[Controller(BaseUrl = "api/cookie-test/")]
class CookieApi
{
	[Post]
	public object successCookie(IHttpContext context)
	{
		HttpParse.AnalyzeCookie(context.Request.Header["Cookie"], context.Request.Cookies);
		return new { Cookie = context.Request.Cookies["TestCookieToken"] };
	}

	[Post]
	public object failCookie(IHttpContext context)
	{
		return new { Cookie = context.Request.Cookies["TestCookieToken"] };
	}
}