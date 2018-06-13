import { Component } from '@angular/core';

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent {
    public currentCount = 0;
    public listeningStart: any;
    private timer: any;

    public hours: number = 0;
    public minutes: number = 0;
    public seconds: number = 0;

    public incrementCounter() {
        this.currentCount++;
    }

    public startTimer() {
        //let _self = this;
        //this.timer = setInterval(function () {
        //    _self.currentCount++;
        //}, 1000);
        this.listeningStart = new Date().getTime();

    }

    public stopTimer() {
        //clearInterval(this.timer);
        let now = new Date().getTime();
        let earn = now - this.listeningStart;

        this.hours = Math.floor((earn % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        this.minutes = Math.floor((earn % (1000 * 60 * 60)) / (1000 * 60));
        this.seconds = Math.floor((earn % (1000 * 60)) / 1000);
    }
}
