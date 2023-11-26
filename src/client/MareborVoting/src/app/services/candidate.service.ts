import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Candidate } from "../models/candidate.model";
import { Observable, Subject } from "rxjs";
import { AppConfigService } from "./app-config.service";
import { GuidHelper } from "../helpers/guid.helper";
import { NotificationService } from "./notification.service";
import { CommandResult } from "../models/command-result.model";
import { ApiService } from "./api.service";

@Injectable({
    providedIn: 'root'
})
export class CandidateService {

    constructor(private httpClient: HttpClient, private appConfigService: AppConfigService, private apiService: ApiService) { }

    getCandidates(): Observable<Candidate[]> {
        return this.httpClient.get<Candidate[]>(`${this.appConfigService.apiUrl}/candidates`);
    }

    addCandidate(name: string): Observable<CommandResult> {
        return this.apiService.sendCommand(`${this.appConfigService.apiUrl}/candidates/add`, { name });
    }
}