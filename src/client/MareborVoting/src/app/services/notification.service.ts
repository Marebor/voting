import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { AppConfigService } from "./app-config.service";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

@Injectable({
    providedIn: 'root'
})
export class NotificationService { // skipping connection errors handling for simplicity

    private hubConnection: HubConnection;
    private subscriptions: { [subscriptionName: string]: Subject<any> } = {};

    constructor(private appConfigService: AppConfigService) {
        this.hubConnection = new HubConnectionBuilder()
            .withUrl(`${this.appConfigService.apiUrl}/notifications`, { withCredentials: false })
            .build();
        this.hubConnection.start().then(() => {
            for (const subcriptionName of Object.keys(this.subscriptions)) {
                this.hubConnection.invoke('Subscribe', subcriptionName);
            }
        });
        
        this.hubConnection.on('SendNotificationAsync', (subscriptionName, data) => {
            const subject = this.subscriptions[subscriptionName];

            if (subject) {
                subject.next(data);
            }
        });
    }

    notification<T>(subcriptionName: string): Observable<T> {
        if (!this.subscriptions[subcriptionName]) {
            this.subscriptions[subcriptionName] = new Subject<T>();

            if (this.hubConnection.state === 'Connected') {
                this.hubConnection.invoke('Subscribe', subcriptionName);
            }
        }

        return this.subscriptions[subcriptionName].asObservable();
    }
}