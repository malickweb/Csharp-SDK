// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// window.kameleoonQueue = window.kameleoonQueue || [];
// const experimentID = 122434; // this value must be correctly entered and corresponds to the experiment's ID in Kameleoon
// window.kameleoonQueue.push(['Experiments.trigger', experimentID, false]); // onlyTracking = true, which means we only activate the experiment's tracking. This is usually what we want with hybrid experiments.

window.kameleoonQueue = window.kameleoonQueue || [];
const experimentID = 122434; // this value must be correctly entered and corresponds to the experiment's ID in Kameleoon
// const variationID = 509993; // this value must be correctly entered and usually corresponds to the value returned by the trigger() method
// window.kameleoonQueue.push(['Experiments.assignVariation', experimentID, variationID]);
window.kameleoonQueue.push(['Experiments.trigger', experimentID, false]); // onlyTracking = true, which means we only activate the experiment's tracking. This is usually what we want with hybrid experiments.
