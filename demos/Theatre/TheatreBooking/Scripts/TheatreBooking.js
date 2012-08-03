/// <reference path="knockout-2.1.0.js" />
/// <reference path="knockout.mapping-latest.debug.js" />

function Seat(options) {
    var seat = ko.mapping.fromJS(options.data);

    seat.bookSeat = function () {
        seat.booked(!seat.booked());
        window.theatre.bookSeat(seat.row(), seat.seatNumber(), seat.booked());
    };

    return seat;
};

function Row(id) {
    var self = this;
    self.id = id;

    self.seats = ko.observableArray();
};

function TheatreViewModel(data, hub) {
    var self = this;

    self.hub = hub;
    self.rows = ko.observableArray();

    ko.mapping.fromJS(data, { seats: seatOptions }, self);

    self.update = function (data) {
        alert(data);
    };
};

var seatOptions = {
    create: Seat
};


