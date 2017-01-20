'use strict';
function checkBrowserIsMozilla(theEvent, args) {
  var currentWindow = window,
    currBrowser = currentWindow.navigator.appCodeName,
    isMozilla = currBrowser === "Mozilla";

  if (isMozilla) {
    alert("Yes");
  } else {
    alert("No");
  }
}