export class PopoverCoordinator {
    static existingInstanceElement;

    static toggle(popoverElem, titleElem, optionsJson) {
        const options = JSON.parse(optionsJson);

        options.title = titleElem;

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

            // `tip` will contain the created element. Make it focusable so that
            // clicks outside are considered a loss of focus.
            instance.tip.tabIndex = 0;
            instance.tip.addEventListener("focusout", (event) => {
                this.destroy(popoverElem);
            });

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
