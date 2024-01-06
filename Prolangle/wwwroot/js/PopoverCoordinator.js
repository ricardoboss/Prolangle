export class PopoverCoordinator {
    static existingInstanceElement;

    static toggle(popoverElem, titleElem, optionsJson) {
        const options = JSON.parse(optionsJson);

        options.title = titleElem.cloneNode(true);

        console.log(`showing with title ${options.title}`)

        let sameElem = false;

        if (this.existingInstanceElement != null && typeof this.existingInstanceElement !== 'undefined') {
            if (this.existingInstanceElement === popoverElem)
                sameElem = true;

            this.destroy(this.existingInstanceElement);
        }

        if (!sameElem) {
            const instance = bootstrap.Popover.getOrCreateInstance(popoverElem, options);

            instance.show();

            this.existingInstanceElement = popoverElem;
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
