mergeInto(LibraryManager.library, {
  SendMessageToNextJS: function(message) {
    window.parent.postMessage({ type: 'FROM_UNITY', message: UTF8ToString(message) }, '*');
  }
});