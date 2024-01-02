export class PopoverCoordinator {
static showOrReplace(elem, optionsJson) {
    const options = JSON.parse(optionsJson);

    bootstrap.Popover.getOrCreateInstance(elem,
        options);
}

static destroy(elem) {
    const tooltip = bootstrap.Popover.getInstance(elem);

    if (tooltip != null && typeof tooltip !== 'undefined') {
        tooltip.dispose();
    }
}
}
