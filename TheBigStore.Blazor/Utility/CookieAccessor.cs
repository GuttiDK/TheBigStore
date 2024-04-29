using Microsoft.JSInterop;

namespace TheBigStore.Blazor.Utility
{
    public class CookieAccessor
    {
        private Lazy<IJSObjectReference> _accessorJsRef = new();
        private readonly IJSRuntime _jsRuntime;
        string expires = "";

        public CookieAccessor(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("initialize");
        }

        public async Task BakeACookie(string key, string value, int? days = null)
        {
            var curExp = (days != null) ? (days > 0 ? DateToUTC(days.Value) : "") : expires;
            await SetCookie($"{key}={value}; expires={curExp}; path=/");
        }
        private async Task SetCookie(string value)
        {
            await _jsRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{value}\"");
        }

        private static string DateToUTC(int days) => DateTime.Now.AddDays(days).ToUniversalTime().ToString("R");

        private async Task WaitForReference()
        {
            if (_accessorJsRef.IsValueCreated is false)
            {
                _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("Cart", "/js/CookieAccessor.js"));
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_accessorJsRef.IsValueCreated)
            {
                await _accessorJsRef.Value.DisposeAsync();
            }
        }

        public async Task<string> GetValueAsync(string key)
        {
            await WaitForReference();
            var result = await _accessorJsRef.Value.InvokeAsync<string>("get", key);

            return result;
        }

        public async Task SetValueAsync<T>(string key, T value)
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
        }
    }
}
