import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { endpoint } from './Services/global.endpoint';
import { contactoService } from './Services/contacto.service';
import { contacto } from './models/contacto';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [contactoService]
})
export class AppComponent {
    public url: string;
    public contactoModel: contacto;
    public visible = false;
    title = 'Silogik.frontEnd';
    constructor(
        private _contacto: contactoService,
        private _route: ActivatedRoute,
        private router: Router
    ) {
        this.url = endpoint.url;
        this.contactoModel = new contacto('', '', '', '', '')
    }

    handleLiveDemoChange(event: any) {
        this.visible = event;
    }

    fileChangeEvent(event: any) {
        const file = event.target.files[0];
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => {
            console.log(reader.result);
        };
    }

    onSubmit() {
        // valida correo 
        var regex = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        var email = this.contactoModel.Email;
        if (!email.match(regex)) {
            alert('Correco electronico no valido:' + email);
        }
        else if (!this.validacionArchivo(this.contactoModel.Archivo)) {
            alert('Solo se permite archivos: Imagen o PDF');
        } else {

        }
    }

    validacionArchivo(archivo: string) {
        var archivo = archivo.split('.')[1].toLocaleLowerCase();
        if (archivo === 'png' || archivo == 'jpg' || archivo === '.pdf') {
            return true;
        }
        return false;
    }
}