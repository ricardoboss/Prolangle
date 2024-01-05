export class PopoverCoordinator {
    static existingInstanceElement;

    static showOrReplace(elem, optionsJson) {
        const options = JSON.parse(optionsJson);

        console.log(`showing with title ${options.title}`)

        if (this.existingInstanceElement != null && typeof this.existingInstanceElement !== 'undefined') {
            this.destroy(this.existingInstanceElement);
        }

        const instance = bootstrap.Popover.getOrCreateInstance(elem, options);

        instance.show();

        this.existingInstanceElement = elem;
    }

    static destroy(elem) {
        const popover = bootstrap.Popover.getInstance(elem);

        if (popover != null && typeof popover !== 'undefined') {
            console.log(`destroying with title ${popover._config.title}`)

            popover.dispose();
        }
    }
}
