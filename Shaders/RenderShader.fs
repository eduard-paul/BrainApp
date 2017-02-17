uniform vec3 Spacing;
uniform vec3 Size;
//uniform sampler3D tex;
uniform samplerCubeShadow tex;

void main(void)
{
   float t1 = 0.5;
   float t2 = 0.5;

   if (gl_FragCoord[0] > 200) t1 = 1;
   if (gl_FragCoord[1] > 300) t2 = 1;

   float f = texture(tex, vec3(gl_FragCoord[0] / 255, gl_FragCoord[1] / 255, 30));

   if (f > 0 && f < 255) {
	gl_FragColor = vec4(f/255, f/255, 0, 1.0);
	return;
   }

   //gl_FragColor = vec4(t1,t2,0, 1.0);
   gl_FragColor = texture(tex, vec3(gl_FragCoord[0] / 255, gl_FragCoord[1] / 255, 30));
}