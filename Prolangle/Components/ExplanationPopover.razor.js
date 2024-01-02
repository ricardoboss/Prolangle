export class ExplanationPopover {
    static init(popoverElem, titleElem, optionsJson) {
        var options = JSON.parse(optionsJson);

        options.title = titleElem;

        bootstrap.Popover.getOrCreateInstance(popoverElem,
            options);
    }

    static destroy(elem) {
        var tooltip = bootstrap.Popover.getInstance(elem);

        if (tooltip != null && typeof tooltip !== 'undefined') {
            tooltip.dispose();
        }
    }
}
