(function () {
    ko.bindingHandlers.object = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            // This will be called when the binding is first applied to an element
            // Set up any initial state, event handlers, etc. here

            var text = $(element).text();
            var value = valueAccessor();

            if (!ko.isObservable(value)) {
                throw new Error("The value must be an observable.");
            }

            try {
                value(JSON.parse(text));
            } catch (e) {
                value(text);
            }
        }
    }
})();