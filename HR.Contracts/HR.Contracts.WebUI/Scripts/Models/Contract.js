var HR = HR || {};
HR.Contracts = HR.Contracts || {};
HR.Contracts.Contract = function () {
    var SALARY_CALCULATE_URL_KEY = "salaryCalculateUrl";
    var TYPE_PARAM_NAME = "contractType";
    var EXPERIENCE_PARAM_NAME = "experience";

    var self = this;

    self.urls = ko.observable();
    self.type = ko.observable();
    self.experience = ko.observable();
    self.salary = ko.observable();

    var calculateSalary = function (newValue) {
        if (self.type() && self.experience()) {
            var url = self.urls()[SALARY_CALCULATE_URL_KEY];
            url = HR.Contracts.Utility.setQueryStringParam(url, TYPE_PARAM_NAME, self.type());
            url = HR.Contracts.Utility.setQueryStringParam(url, EXPERIENCE_PARAM_NAME, self.experience());

            $.getJSON(url, function (data) {
                self.salary(data);
            });
        } else {
            self.salary(0);
        }
    };
    
    self.type.subscribe(calculateSalary);
    self.experience.subscribe(calculateSalary);
};