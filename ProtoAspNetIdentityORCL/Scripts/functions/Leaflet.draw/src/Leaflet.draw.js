/*
 * Leaflet.draw assumes that you have already included the Leaflet library.
 */

L.drawVersion = '0.2.4-dev';

L.drawLocal = {
	draw: {
		toolbar: {
			actions: {
				title: 'Cancelar Dibujo',
				text: 'Cancelar'
			},
			undo: {
				title: 'Borrar último punto del dibujo',
				text: 'Borrar último punto'
			},
			buttons: {
				polyline: 'Dibujar una línea de varios puntos',
				polygon: 'Dibujar un polígono',
				rectangle: 'Dibujar un rectángulo',
				circle: 'Dibujar un círculo',
				marker: 'Dibujar una marca de punto'
			}
		},
		handlers: {
			circle: {
				tooltip: {
					start: 'Haga clic y arrastre para dibujar el círculo.'
				},
				radius: 'Radio'
			},
			marker: {
				tooltip: {
					start: 'Haga clic sobre el lugar a marcar en el mapa.'
				}
			},
			polygon: {
				tooltip: {
					start: 'Haga clic para empezar a dibujar el polígono.',
					cont: 'Marque el siguiente vértice del polígono.',
					end: 'Haga clic sobre el primer punto o doble clic para cerrar el polígono'
				}
			},
			polyline: {
				error: '<strong>Error:</strong> la línea no debe cruzar el polígono!',
				tooltip: {
					start: 'Haga clic para empezar a dibujar la línea.',
					cont: 'Marque el siguiente punto de la línea.',
					end: 'Haga clic sobre el último punto o doble clic para finalizar la línea'
				}
			},
			rectangle: {
				tooltip: {
					start: 'Haga clic y arrastre para dibujar el rectángulo.'
				}
			},
			simpleshape: {
				tooltip: {
					end: 'Suelte el desplamiento del mouse para terminar de dibujar.'
				}
			}
		}
	},
	edit: {
		toolbar: {
			actions: {
				save: {
					title: 'Guardar Cambios.',
					text: 'Guardar'
				},
				cancel: {
					title: 'Cancelar la edición, descartar todos los cambios.',
					text: 'Cancelar'
				}
			},
			buttons: {
				edit: 'Editar formas dibujo.',
				editDisabled: 'No hay dibujos para editar.',
				remove: 'Borrar formas de dibujo.',
				removeDisabled: 'No hay dibujos para borrar.'
			}
		},
		handlers: {
			edit: {
				tooltip: {
					text: 'Arrastre el punto para editar la forma.',
					subtext: 'Haga clic en Cancelar para deshacer los cambios.'
				}
			},
			remove: {
				tooltip: {
					text: 'Haga clic sobre una figura para eliminar.'
				}
			}
		}
	}
};
