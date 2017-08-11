import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent }  from './app.component';
import { DepartmentService, UserService } from './services/index';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
    ],
    declarations: [
        AppComponent
    ],
    providers: [
        DepartmentService,
        UserService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
