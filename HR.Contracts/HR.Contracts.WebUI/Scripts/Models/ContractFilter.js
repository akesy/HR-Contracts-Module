var HR = HR || {};
HR.Contracts = HR.Contracts || {};
HR.Contracts.ContractFilter = function () {
    var NAME_PARAM_NAME = "name";
    var TYPE_PARAM_NAME = "type";
    var EXPERIENCE_PARAM_NAME = "experience";
    var SALARY_EQUAL_TO_PARAM_NAME = "salaryEqualTo";
    var CONTRACTS_LIST_URL_KEY = "contractListUrl";

    var self = this;

    self.urls = ko.observable();
    self.name = ko.observable(HR.Contracts.Utility.getQueryStringParam(NAME_PARAM_NAME));
    self.type = ko.observable(HR.Contracts.Utility.getQueryStringParam(TYPE_PARAM_NAME));
    self.experience = ko.observable(HR.Contracts.Utility.getQueryStringParam(EXPERIENCE_PARAM_NAME));
    self.salaryEqualTo = ko.observable(HR.Contracts.Utility.getQueryStringParam(SALARY_EQUAL_TO_PARAM_NAME));

    self.filter = function (key) {
        var url;
        if (key) {
            url = self.urls()[key];
        } else {
            url = self.urls()[CONTRACTS_LIST_URL_KEY];
            url = trySetQueryStringParam(url, NAME_PARAM_NAME, self.name());
            url = trySetQueryStringParam(url, TYPE_PARAM_NAME, self.type());
            url = trySetQueryStringParam(url, EXPERIENCE_PARAM_NAME, self.experience());
            url = trySetQueryStringParam(url, SALARY_EQUAL_TO_PARAM_NAME, self.salaryEqualTo());
        }
        
        window.location.href = url;
    };

    self.reset = function () {
        self.name("");
        self.type("");
        self.experience("");
        self.salaryEqualTo("");

        window.location.href = self.urls()[CONTRACTS_LIST_URL_KEY];
    };
};

var trySetQueryStringParam = function (url, key, value) {
    return value ? HR.Contracts.Utility.setQueryStringParam(url, key, value) : url;
}