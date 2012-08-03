/// <reference path="../jQuery-1.7.2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />

function LifeViewModel(data) {
    var self = this;
    
    self.isRunning = 'undefined';    
    self.cells = ko.observableArray([]);
    self.width = ko.observable(data.width);
    self.height = ko.observable(data.height);
    self.nextRoundLiveness = [];

    self.rows = ko.observableArray([]);

    for (var i = 0; i < self.height() ; i++) {
        self.rows().push(new Row(self.width()));
    }

    self.stop = function () {
        clearInterval(self.isRunning);
        self.isRunning = 'undefined';
    };
    
    self.run = function () {
        self.nextRoundLiveness = [];
        for (var y = 0; y < self.height() ; y++) {
            for (var x = 0; x < self.width() ; x++) {
                self.buildNextRoundLiveness(x, y);
            }
        }
        for (var j = 0; j < self.nextRoundLiveness.length; j++) {
            var xndx = self.truncate(j % self.width());
            var yndx = self.truncate(j / self.height());

            self.rows()[yndx].cells()[xndx].alive(self.nextRoundLiveness[j]);
        }
        if(self.isRunning === 'undefined')
            self.isRunning = setInterval(self.run, 500);
    };

    self.buildNextRoundLiveness = function (x, y) {
        var liveness = 0;
        for (var j = y - 1; j <= y + 1; j++) {
            for (var i = x - 1; i <= x + 1; i++) {
                var xndx, yndx;
                xndx = i;
                yndx = j;
                if (i < 0) xndx = i + self.width();
                if (i >= self.width()) xndx = i - self.width();
                if (j < 0) yndx = j + self.height();
                if (j >= self.height()) yndx = j - self.height();

                var cell = self.rows()[yndx].cells()[xndx];
                if (cell.alive() && !(x == xndx && y == yndx)) {
                    liveness++;
                }
            }
        }
        if ((liveness === 2 || liveness === 3) && self.rows()[y].cells()[x].alive())
            self.nextRoundLiveness.push(true);
        else if (liveness === 3 && !self.rows()[y].cells()[x].alive())
            self.nextRoundLiveness.push(true);
        else
            self.nextRoundLiveness.push(false);
    };

    self.truncate = function(n) {
        return n | 0;
    };
}

function Row(width) {
    var self = this;
    self.left = 0;
    self.right = width - 1;

    self.cells = ko.observableArray([]);

    for (var i = 0; i < width; i++) {
        self.cells().push(new Cell(false));
    }
}
function Cell(alive) {
    var self = this;

    self.alive = ko.observable(alive);

    self.live = function () {
        self.alive(!self.alive());
    };
}