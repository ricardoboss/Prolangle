function getBoundingBox(id) {
    const element = document.getElementById(id);
    const rect = element.getBoundingClientRect();

    return {
        X: rect.left,
        Y: rect.top,
        Width: rect.width,
        Height: rect.height
    };
}

async function shareResult(text) {
    if (!navigator.share && !navigator.clipboard) {
        return "Your browser does not support sharing or copying to clipboard.";
    }

    const shareData = {
        text: text,
    };

    if (!navigator.share || !navigator.canShare(shareData)) {
        await navigator.clipboard.writeText(text);

        return "Result copied to clipboard.";
    }

    try {
        await navigator.share(shareData);
    } catch (e) {
        console.warn('Error occurred during share sheet: ', e);
    }

    return "Share dialog opened.";
}
