// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getStandartViewOfDate(partOfDate, numbersLimit) {
    var partOfDateString = `${partOfDate}`;
    while (partOfDateString.length < numbersLimit) {
        partOfDateString = `0${partOfDate}`;
    }

    return partOfDateString;
}

function getFormattedDateString(date) {
    var dateString = `${getStandartViewOfDate(date.getFullYear(), 4)}`
    dateString = dateString + `.${getStandartViewOfDate(date.getMonth(), 2)}`;
    dateString = dateString + `.${getStandartViewOfDate(date.getDate(), 2)}`;
    dateString = dateString + ` ${getStandartViewOfDate(date.getHours(), 2)}`;
    dateString = dateString + `:${getStandartViewOfDate(date.getMinutes(), 2)}`;
    dateString = dateString + `:${getStandartViewOfDate(date.getSeconds(), 2)}`;
    dateString = dateString + `.${getStandartViewOfDate(date.getMilliseconds(), 3)}`;

    return dateString;
}