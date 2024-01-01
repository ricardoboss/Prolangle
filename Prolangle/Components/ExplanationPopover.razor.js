export class ExplanationPopover {
    static init(elem, optionsJson) {
        var options = JSON.parse(optionsJson);

        bootstrap.Popover.getOrCreateInstance(elem,
            options);
    }

    static destroy(elem) {
        var tooltip = bootstrap.Popover.getInstance(elem);

        if (tooltip != null && typeof tooltip !== 'undefined') {
            tooltip.dispose();
        }
    }
}
