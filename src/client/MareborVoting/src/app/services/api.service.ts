import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { GuidHelper } from "../helpers/guid.helper";
import { NotificationService } from "./notification.service";
import { CommandResult } from "../models/command-result.model";

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    constructor(private httpClient: HttpClient, private notificationService: NotificationService) { }

    sendCommand(url: string, payload: any): Observable<CommandResult> {
        const commandId = GuidHelper.GuidV4();
        const subject = new Subject<CommandResult>();
        this.notificationService.notification<CommandResult>(commandId).subscribe(result => {
            subject.next(result);
            subject.complete();
        });
        this.httpClient.post<void>(url, {
            commandId,
            ...payload
        }).subscribe();
        
        return subject.asObservable();
    }
}