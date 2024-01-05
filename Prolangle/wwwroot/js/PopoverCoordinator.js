export class PopoverCoordinator {
    static existingInstanceElement;

    static toggle(elem, optionsJson) {
        const options = JSON.parse(optionsJson);

        console.log(`showing with title ${options.title}`)

        let sameElem = false;

        if (this.existingInstanceElement != null && typeof this.existingInstanceElement !== 'undefined') {
            if (this.existingInstanceElement === elem)
                sameElem = true;

            this.destroy(this.existingInstanceElement);
        }

        if (!sameElem) {
            const instance = bootstrap.Popover.getOrCreateInstance(elem, options);

            instance.show();

            this.existingInstanceElement = elem;
        }
        else {
            this.existingInstanceElement = null;
        }
    }

    static destroy(elem) {
        const popover = bootstrap.Popover.getInstance(elem);

        if (popover != null && typeof popover !== 'undefined') {
            console.log(`destroying with title ${popover._config.title}`)

            popover.dispose();
        }
    }
}
