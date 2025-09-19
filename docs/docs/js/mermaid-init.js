// Initialize Mermaid with clickable links allowed
document.addEventListener("DOMContentLoaded", () => {
  if (window.mermaid) {
    window.mermaid.initialize({
      startOnLoad: true,
      securityLevel: "loose" // enables links (click ...)
    });
  }
});
