import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListarComponent } from './listar/listar.component';
import { CadastroComponent } from './cadastro.component';
import { CadastroRoutingModule } from './cadastro-routing.module';
import { CriarComponent } from './criar/criar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditarComponent } from './editar/editar.component';
import { ExcluirComponent } from './excluir/excluir.component';

@NgModule({
  declarations: [ListarComponent, CadastroComponent, CriarComponent, EditarComponent, ExcluirComponent],
  imports: [
    CommonModule,
    CadastroRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class CadastroModule {}
