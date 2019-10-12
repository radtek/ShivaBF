var app = angular.module('InventoryApp');
app.directive('ngDate', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        compile: function () {
            return {
                pre: function (scope, element, attrs, ngModelCtrl) {
                    var format = (!attrs.dpformat) ? 'dd/mm/yyyy' : attrs.dpformat;
                    // Initialize the date-picker
                    $(element).datepicker({
                        autoclose: true,
                        format: format
                    }).on('changeDate', function (ev) {
                        // To me this looks cleaner than adding $apply(); after everything.
                        angular.element($(this)).triggerHandler('input');
                    });
                }
            }
        }
    }
});
app.directive('icheck', ['$timeout', '$parse', function ($timeout, $parse) {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attr, ngModel) {
            $timeout(function () {
                var value = attr.value;

                function update(checked) {
                    if (attr.type === 'radio') {
                        ngModel.$setViewValue(value);
                    } else {
                        ngModel.$setViewValue(checked);
                    }
                }

                $(element).iCheck({
                    checkboxClass: attr.checkboxClass || 'icheckbox_square-green',
                    radioClass: attr.radioClass || 'iradio_square-green'
                }).on('ifChanged', function (e) {
                    scope.$apply(function () {
                        update(e.target.checked);
                    });
                });

                scope.$watch(attr.ngChecked, function (checked) {
                    if (typeof checked === 'undefined') checked = !!ngModel.$viewValue;
                    update(checked)
                }, true);

                scope.$watch(attr.ngModel, function (model) {
                    $(element).iCheck('update');
                }, true);

            })
        }
    }
}]);
app.directive('ckEditor', function () {
    return {
        require: '?ngModel',
        link: function (scope, elm, attr, ngModel) {
            var ck = CKEDITOR.replace(elm[0]);
            if (!ngModel) return;
            ck.on('instanceReady', function () {
                ck.setData(ngModel.$viewValue);
            });
            function updateModel() {
                scope.$apply(function () {
                    ngModel.$setViewValue(ck.getData());
                });
            }
            ck.on('change', updateModel);
            ck.on('key', updateModel);
            ck.on('dataReady', updateModel);
            ngModel.$render = function (value) {
                ck.setData(ngModel.$viewValue);
            };
        }
    };
});



//https://cdnjs.cloudflare.com/ajax/libs/wysihtml5/0.3.0/wysihtml5.min.js
app.directive('wysiwyg', function ($document) {
    return {
        restrict: "A",
        require: "ngModel",
        template: "<textarea style='width: 100%;height:100%' placeholder='Enter your text ...'></textarea>",
        replace: true,
        link: function (scope, element, attrs, controller) {
            var styleSheets,
                synchronize, editor,
                wysihtml5ParserRules = {
                    tags: {
                        strong: {}, b: {}, i: {}, em: {}, br: {}, p: {},
                        div: {}, span: {}, ul: {}, ol: {}, li: {},
                        h1: {}, h2: {},
                        a: {
                            set_attributes: {
                                target: "_blank",
                                rel: "nofollow"
                            },
                            check_attributes: {
                                href: "url" // important to avoid XSS
                            }
                        }
                    }
                };

            //styleSheets = _($document[0].styleSheets)
            //    .filter(function (ss) { return ss.href; })
            //    .pluck('href').value();

            editor = new wysihtml5.Editor(element[0], {
                toolbar: attrs.wysiwygToolbar, // id of toolbar element
                parserRules: wysihtml5ParserRules, // defined in parser rules set
                useLineBreaks: false,
                //stylesheets: styleSheets
            });

            synchronize = function () {
                controller.$setViewValue(editor.getValue());
                scope.$apply();
            };

            editor.on('redo:composer', synchronize);
            editor.on('undo:composer', synchronize);
            editor.on('paste', synchronize);
            editor.on('aftercommand:composer', synchronize);
            editor.on('change', synchronize);

            // the secret sauce to update every keystroke, may be cheating but it works
            editor.on('load', function () {
                wysihtml5.dom.observe(
                    editor.currentView.iframe.contentDocument.body,
                    ['keyup'], synchronize);
            });

            // handle changes to model from outside the editor
            scope.$watch(attrs.ngModel, function (newValue) {
                // necessary to prevent thrashing
                if (newValue && (newValue !== editor.getValue())) {
                    element.html(newValue);
                    editor.setValue(newValue);
                }
            });
        }
    };
});
