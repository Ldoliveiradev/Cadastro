import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroComponent } from './cadastro.component';
import { CriarComponent } from './criar/criar.component';
import { EditarComponent } from './editar/editar.component';
import { ExcluirComponent } from './excluir/excluir.component';
import { ListarComponent } from './listar/listar.component';

const cadastroRoutes: Routes = [
  {
    path: '',
    component: CadastroComponent,
    children: [
      { path: 'listar-todos', component: ListarComponent },
      { path: 'criar', component: CriarComponent },
      { path: 'editar/:id', component: EditarComponent },
      { path: 'excluir/:id', component: ExcluirComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(cadastroRoutes)],
  exports: [RouterModule],
})
export class CadastroRoutingModule {}
