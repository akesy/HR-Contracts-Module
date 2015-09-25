var HR = HR || {};
HR.Contracts = HR.Contracts || {};
HR.Contracts.Utility = {
	getQueryStringParam: function (variable) {
		var query = window.location.search.substring(1);
		var vars = query.split('&');

		for (var i = 0; i < vars.length; i++) {
			var pair = vars[i].split('=');
			if (decodeURIComponent(pair[0]) == variable) {
				return decodeURIComponent(pair[1]);
			}
		}

		return "";
	},

	setQueryStringParam: function (url, key, value) {
		if (!url) {
			return "";
		}

		var parts = url.split('?');
		var keyValuePair = key + "=" + value;
		var delimeter = parts.length > 1 ? '&' : '?';

		return url + delimeter + keyValuePair;
	}
};