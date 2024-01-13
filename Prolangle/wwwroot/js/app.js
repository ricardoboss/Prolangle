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

async function writeTextToClipboard(text) {
    await navigator.clipboard.writeText(text);
}
